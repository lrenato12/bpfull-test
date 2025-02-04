namespace bpfull_core.Utils.Validator;

/// <summary>
/// Interface para validação de números de CPF.
/// </summary>
public interface IValidatorCPF
{
    /// <summary>
    /// Valida se o CPF fornecido está em um formato válido.
    /// </summary>
    /// <param name="cpf">O número de CPF a ser validado.</param>
    /// <returns>Retorna true se o CPF for válido; caso contrário, retorna false.</returns>
    bool ValidarCPF(string cpf);
}