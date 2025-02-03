using System.Text.RegularExpressions;

namespace bpfull_core.Utils.StringFormatter;

public class StringFormatter : IStringFormatter
{
    public string ObterSomenteNumeros(string input)
    {
        return Regex.Replace(input, @"\D", string.Empty);
    }
}