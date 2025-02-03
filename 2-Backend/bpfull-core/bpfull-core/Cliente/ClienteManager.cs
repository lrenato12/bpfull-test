using AutoMapper;
using bpfull_core.Base;
using bpfull_infrastructure.Cliente;
using bpfull_infrastructure.Contato;
using bpfull_infrastructure.Data;
using bpfull_infrastructure.Documento;
using bpfull_infrastructure.Endereco;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Contato;
using bpfull_shared.Model.Documento;
using bpfull_shared.Model.Endereco;
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
    private readonly IMapper _mapper;
    #endregion

    #region [ CONSTRUCTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor
        , IClienteDAL clienteDAL
        , IContatoDAL contatoDAL
        , IDocumentoDAL documentoDAL
        , IEnderecoDAL enderecoDAL
        , IUnitOfWork unitOfWork
        , IMapper mapper)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _contatoDAL = contatoDAL;
        _documentoDAL = documentoDAL;
        _enderecoDAL = enderecoDAL;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task<ApiResultModel> Create(ClienteRequestModel requestModel)
    {
        _unitOfWork.BeginTransaction();

        requestModel.ClienteId = await _clienteDAL.Create(_mapper.Map<ClienteModel>(requestModel));
        
        requestModel.ContatoId = await _contatoDAL.Create(_mapper.Map<ContatoModel>(requestModel));
        
        requestModel.DocumentoId = await _documentoDAL.Create(_mapper.Map<DocumentoModel>(requestModel));
        
        requestModel.EnderecoId = await _contatoDAL.Create(_mapper.Map<EnderecoModel>(requestModel));

        _unitOfWork.Commit();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Get()
    {
        var result = await _clienteDAL.Get();

        return new ApiResultModel().WithSuccess(result);
    }
}