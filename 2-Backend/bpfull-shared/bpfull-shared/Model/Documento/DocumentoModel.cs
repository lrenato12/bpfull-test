namespace bpfull_shared.Model.Documento;

/// <summary>
/// Model for Documento model.
/// </summary>
public class DocumentoModel
{
    public string Id { get; set; }
    public string ClienteId { get; set; }
    public string CPF { get; set; }
    public string CNPJ { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}