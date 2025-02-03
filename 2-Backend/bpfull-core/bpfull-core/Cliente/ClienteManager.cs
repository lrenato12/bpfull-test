using bpfull_core.Base;
using bpfull_infrastructure.Cliente;
using bpfull_infrastructure.Contato;
using bpfull_infrastructure.Data;
using bpfull_infrastructure.Documento;
using bpfull_infrastructure.Endereco;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;
using Microsoft.AspNetCore.Http;

namespace bpfull_core.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    private readonly IContatoDAL _contatoDAL;
    private readonly IDocumentoDAL _documentoDAL;
    private readonly IEnderecoDAL _enderecoDAL;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region [ CONSTRUCTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor
        , IClienteDAL clienteDAL
        , IContatoDAL contatoDAL
        , IDocumentoDAL documentoDAL
        , IEnderecoDAL enderecoDAL
        , IUnitOfWork unitOfWork)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _contatoDAL = contatoDAL;
        _documentoDAL = documentoDAL;
        _enderecoDAL = enderecoDAL;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task<ApiResultModel> Create(ClienteModel requestModel)
    {
        _unitOfWork.BeginTransaction();

        var result = await _clienteDAL.Create(requestModel);
        result = await _contatoDAL.Create(requestModel);
        result = await _documentoDAL.Create(requestModel);
        result = await _enderecoDAL.Create(requestModel);
        
        _unitOfWork.Commit();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Get()
    {
        var result = await _clienteDAL.Get();

        return new ApiResultModel().WithSuccess(result);
    }
}