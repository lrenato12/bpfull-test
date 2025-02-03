using AutoMapper;
using bpfull_core.Base;
using bpfull_core.Utils.StringFormatter;
using bpfull_core.Utils.Validator;
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
    private readonly IStringFormatter _stringFormatter;
    private readonly IRequestValidator<ClienteRequestModel> _clienteRequestValidator;
    #endregion

    #region [ CONSTRUCTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor
        , IClienteDAL clienteDAL
        , IContatoDAL contatoDAL
        , IDocumentoDAL documentoDAL
        , IEnderecoDAL enderecoDAL
        , IUnitOfWork unitOfWork
        , IMapper mapper
        , IStringFormatter stringFormatter
        , IRequestValidator<ClienteRequestModel> clienteRequestValidator)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _contatoDAL = contatoDAL;
        _documentoDAL = documentoDAL;
        _enderecoDAL = enderecoDAL;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _stringFormatter = stringFormatter;
        _clienteRequestValidator = clienteRequestValidator;
    }
    #endregion

    public async Task<ApiResultModel> Create(ClienteRequestModel requestModel)
    {
        // Validação do modelo
        var resultadoValidacao = _clienteRequestValidator.ValidateRequest(requestModel);
        if (!resultadoValidacao.Success)
        {
            return resultadoValidacao;
        }

        try
        {
            // Inicia a transação
            _unitOfWork.BeginTransaction();

            // Criação das entidades
            requestModel.ClienteId = await CreateCliente(requestModel);
            requestModel.ContatoId = await CreateContato(requestModel);
            requestModel.DocumentoId = await CreateDocumento(requestModel);
            requestModel.EnderecoId = await CreateEndereco(requestModel);

            // Commit da transação
            _unitOfWork.Commit();

            // Retorna sucesso
            return new ApiResultModel().WithSuccess(requestModel);
        }
        catch (Exception ex)
        {
            // Em caso de erro, realiza rollback
            _unitOfWork.Rollback();
            return new ApiResultModel().WithError($"Erro inesperado: {ex.Message}");
        }
    }

    private async Task<string> CreateCliente(ClienteRequestModel requestModel)
    {
        var clienteModel = _mapper.Map<ClienteModel>(requestModel);
        var clienteId = await _clienteDAL.Create(clienteModel);
        if (string.IsNullOrEmpty(clienteId))
        {
            throw new Exception("Erro ao criar o cliente.");
        }
        return clienteId;
    }

    private async Task<string> CreateContato(ClienteRequestModel requestModel)
    {
        var contatoModel = _mapper.Map<ContatoModel>(requestModel);
        var contatoId = await _contatoDAL.Create(contatoModel);
        if (string.IsNullOrEmpty(contatoId))
        {
            throw new Exception("Erro ao criar o contato.");
        }
        return contatoId;
    }

    private async Task<string> CreateDocumento(ClienteRequestModel requestModel)
    {
        var documentoModel = _mapper.Map<DocumentoModel>(requestModel);

        if(!string.IsNullOrEmpty(documentoModel.CPF))
            documentoModel.CPF = _stringFormatter.ObterSomenteNumeros(documentoModel.CPF);
        else if (!string.IsNullOrEmpty(documentoModel.CNPJ))
            documentoModel.CNPJ = _stringFormatter.ObterSomenteNumeros(documentoModel.CNPJ);

        var documentoId = await _documentoDAL.Create(documentoModel);
        if (string.IsNullOrEmpty(documentoId))
        {
            throw new Exception("Erro ao criar o documento.");
        }
        return documentoId;
    }

    private async Task<string> CreateEndereco(ClienteRequestModel requestModel)
    {
        var enderecoModel = _mapper.Map<EnderecoModel>(requestModel);
        var enderecoId = await _enderecoDAL.Create(enderecoModel);
        if (string.IsNullOrEmpty(enderecoId))
        {
            throw new Exception("Erro ao criar o endereço.");
        }
        return enderecoId;
    }

    public async Task<ApiResultModel> Get()
    {
        var result = await _clienteDAL.Get();

        return new ApiResultModel().WithSuccess(result);
    }
}