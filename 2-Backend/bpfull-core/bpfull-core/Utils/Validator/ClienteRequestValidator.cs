using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;

namespace bpfull_core.Utils.Validator;

public class ClienteRequestValidator : IRequestValidator<ClienteRequestModel>
{
    private readonly IValidatorEmail _emailValidator;
    private readonly IValidatorCPF _cpfValidator;
    private readonly IValidatorCNPJ _cnpjValidator;

    public ClienteRequestValidator(
        IValidatorEmail emailValidator,
        IValidatorCPF cpfValidator,
        IValidatorCNPJ cnpjValidator)
    {
        _emailValidator = emailValidator;
        _cpfValidator = cpfValidator;
        _cnpjValidator = cnpjValidator;
    }

    public ApiResultModel ValidateRequest(ClienteRequestModel requestModel)
    {
        if (string.IsNullOrEmpty(requestModel.Nome))
        {
            return new ApiResultModel().WithError("O nome é obrigatório.");
        }

        if (string.IsNullOrEmpty(requestModel.Email) || !_emailValidator.ValidarEmail(requestModel.Email))
        {
            return new ApiResultModel().WithError("Email inválido ou não informado.");
        }

        if (string.IsNullOrEmpty(requestModel.Telefone))
        {
            return new ApiResultModel().WithError("Telefone é obrigatório.");
        }

        if (string.IsNullOrEmpty(requestModel.CPF) && string.IsNullOrEmpty(requestModel.CNPJ))
        {
            return new ApiResultModel().WithError("É necessário informar CPF ou CNPJ.");
        }

        // Validações adicionais para cada tipo de documento
        if (!string.IsNullOrEmpty(requestModel.CPF) && !_cpfValidator.ValidarCPF(requestModel.CPF))
        {
            return new ApiResultModel().WithError("CPF inválido.");
        }

        if (!string.IsNullOrEmpty(requestModel.CNPJ) && !_cnpjValidator.ValidarCNPJ(requestModel.CNPJ))
        {
            return new ApiResultModel().WithError("CNPJ inválido.");
        }

        if (string.IsNullOrEmpty(requestModel.CEP))
        {
            return new ApiResultModel().WithError("CEP é obrigatório.");
        }

        if (string.IsNullOrEmpty(requestModel.Pais))
        {
            requestModel.Pais = "Brasil";
        }

        return new ApiResultModel().WithSuccess("Dados válidos.");
    }
}