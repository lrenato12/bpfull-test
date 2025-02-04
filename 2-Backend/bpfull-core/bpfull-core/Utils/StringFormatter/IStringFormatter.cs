namespace bpfull_core.Utils.StringFormatter;

/// <summary>
/// Interface para formatação de strings.
/// </summary>
public interface IStringFormatter
{
    /// <summary>
    /// Obtém somente os números de uma string de entrada.
    /// </summary>
    /// <param name="input">A string de entrada da qual os números devem ser extraídos.</param>
    /// <returns>Uma string contendo apenas os números extraídos.</returns>
    string ObterSomenteNumeros(string input);
}