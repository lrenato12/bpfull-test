namespace bpfull_core.Utils.Validator;

/// <summary>
/// Interface para validação de números de CNPJ.
/// </summary>
public interface IValidatorCNPJ
{
    /// <summary>
    /// Valida se o CNPJ fornecido está em um formato válido.
    /// </summary>
    /// <param name="cnpj">O número de CNPJ a ser validado.</param>
    /// <returns>Retorna true se o CNPJ for válido; caso contrário, retorna false.</returns>
    bool ValidarCNPJ(string cnpj);
}