namespace bpfull_shared.Model.Documento;

public class DocumentoModel
{
    public string Id { get; set; }
    public string ClienteId { get; set; }
    public string CPF { get; set; }
    public string CNPJ { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}