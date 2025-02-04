namespace bpfull_shared.Model.Endereco;

/// <summary>
/// Model for Endereco model.
/// </summary>
public class EnderecoModel
{
    public string Id { get; set; }
    public string ClienteId { get; set; }
    public string CEP { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}