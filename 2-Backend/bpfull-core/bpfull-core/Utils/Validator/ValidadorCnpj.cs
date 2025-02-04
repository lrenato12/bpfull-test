using System.Text.RegularExpressions;

namespace bpfull_core.Utils.Validator;

/// <summary>
/// Classe responsável pela validação de números de CNPJ.
/// Implementa a interface <see cref="IValidatorCNPJ"/>.
/// </summary>
public class ValidadorCnpj : IValidatorCNPJ
{
    /// <summary>
    /// Valida se o CNPJ fornecido está em um formato válido.
    /// </summary>
    /// <param name="cnpj">O número de CNPJ a ser validado.</param>
    /// <returns>Retorna true se o CNPJ for válido; caso contrário, retorna false.</returns>
    public bool ValidarCNPJ(string cnpj)
    {
        var regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");
        return regex.IsMatch(cnpj);
    }
}