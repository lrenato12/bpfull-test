namespace bpfull_core.Utils.Validator;

using System.Text.RegularExpressions;

/// <summary>
/// Classe responsável pela validação de endereços de e-mail.
/// Implementa a interface <see cref="IValidatorEmail"/>.
/// </summary>
public class ValidadorEmail : IValidatorEmail
{
    /// <summary>
    /// Valida se o e-mail fornecido está em um formato válido.
    /// </summary>
    /// <param name="email">O endereço de e-mail a ser validado.</param>
    /// <returns>Retorna true se o e-mail for válido; caso contrário, retorna false.</returns>
    public bool ValidarEmail(string email)
    {
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.IsMatch(email);
    }
}