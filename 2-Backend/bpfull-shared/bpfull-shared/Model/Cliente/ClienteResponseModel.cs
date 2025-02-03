namespace bpfull_shared.Model.Cliente;

public class ClienteResponseModel
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Documento { get; set; }
    public string? CEP { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Pais { get; set; }
}