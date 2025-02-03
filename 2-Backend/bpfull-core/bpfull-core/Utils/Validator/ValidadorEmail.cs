namespace bpfull_core.Utils.Validator;

using System.Text.RegularExpressions;

public class ValidadorEmail : IValidatorEmail
{
    public bool ValidarEmail(string email)
    {
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

        return regex.IsMatch(email);
    }
}