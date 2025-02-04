namespace bpfull_shared.Model.Cliente;

/// <summary>
/// Model for Cliente model.
/// </summary>
public class ClienteModel
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}