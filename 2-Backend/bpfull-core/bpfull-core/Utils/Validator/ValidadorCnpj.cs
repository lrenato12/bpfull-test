using System.Text.RegularExpressions;

namespace bpfull_core.Utils.Validator;

public class ValidadorCnpj : IValidatorCNPJ
{
    public bool ValidarCNPJ(string cnpj)
    {
        var regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");

        return regex.IsMatch(cnpj);
    }
}