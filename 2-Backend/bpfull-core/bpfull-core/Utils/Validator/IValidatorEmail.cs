namespace bpfull_core.Utils.Validator;

/// <summary>
/// Interface para validação de endereços de e-mail.
/// </summary>
public interface IValidatorEmail
{
    /// <summary>
    /// Valida se o e-mail fornecido está em um formato válido.
    /// </summary>
    /// <param name="email">O endereço de e-mail a ser validado.</param>
    /// <returns>Retorna true se o e-mail for válido; caso contrário, retorna false.</returns>
    bool ValidarEmail(string email);
}