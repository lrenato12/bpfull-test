using bpfull_core.Base;
using bpfull_infrastructure.Cliente;
using bpfull_infrastructure.Data;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;
using Microsoft.AspNetCore.Http;

namespace bpfull_core.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region [ CONSTRUCTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor, IClienteDAL clienteDAL, IUnitOfWork unitOfWork)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task<ApiResultModel> AddCliente(ClienteModel requestModel)
    {
        _unitOfWork.BeginTransaction();

        var result = await _clienteDAL.AddCliente(requestModel);

        _unitOfWork.Commit();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAllCliente()
    {
        var result = await _clienteDAL.GetAllCliente();

        return new ApiResultModel().WithSuccess(result);
    }
}