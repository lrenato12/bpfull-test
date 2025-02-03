using System.Text.RegularExpressions;

namespace bpfull_core.Utils.Validator;

public class ValidadorCpf : IValidatorCPF
{
    public bool ValidarCPF(string cpf)
    {
        var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

        return regex.IsMatch(cpf);
    }
}