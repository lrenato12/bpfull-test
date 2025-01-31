using bpfull_core.Base;
using bpfull_infrastructure.Cliente;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;
using Microsoft.AspNetCore.Http;

namespace bpfull_core.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    #endregion

    #region [ CONSTRUCTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor, IClienteDAL clienteDAL)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
    }
    #endregion

    public async Task<ApiResultModel> AddCliente(ClienteModel requestModel)
    {
        var result = await _clienteDAL.AddCliente(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAllCliente()
    {
        var result = await _clienteDAL.GetAllCliente();

        return new ApiResultModel().WithSuccess(result);
    }
}