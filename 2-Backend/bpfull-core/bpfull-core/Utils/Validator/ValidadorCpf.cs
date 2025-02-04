using System.Text.RegularExpressions;

namespace bpfull_core.Utils.Validator;

/// <summary>
/// Classe responsável pela validação de números de CPF.
/// Implementa a interface <see cref="IValidatorCPF"/>.
/// </summary>
public class ValidadorCpf : IValidatorCPF
{
    /// <summary>
    /// Valida se o CPF fornecido está em um formato válido.
    /// </summary>
    /// <param name="cpf">O número de CPF a ser validado.</param>
    /// <returns>Retorna true se o CPF for válido; caso contrário, retorna false.</returns>
    public bool ValidarCPF(string cpf)
    {
        var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        return regex.IsMatch(cpf);
    }
}