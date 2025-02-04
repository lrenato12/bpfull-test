using System.Text.RegularExpressions;

namespace bpfull_core.Utils.StringFormatter;

/// <summary>
/// Classe responsável pela formatação de strings.
/// Implementa a interface <see cref="IStringFormatter"/>.
/// </summary>
public class StringFormatter : IStringFormatter
{
    /// <summary>
    /// Remove todos os caracteres não numéricos de uma string.
    /// </summary>
    /// <param name="input">A string de entrada da qual os números devem ser extraídos.</param>
    /// <returns>Uma string contendo apenas os números.</returns>
    public string ObterSomenteNumeros(string input)
    {
        return Regex.Replace(input, @"\D", string.Empty);
    }
}