namespace bpfull_shared.Model.Cliente
{
    public class ClienteRequestModel
    {
        public string ClienteId { get; set; }
        public string ContatoId { get; set; }
        public string DocumentoId { get; set; }
        public string EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TipoDocumento { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string Estado { get; set; }
    }
}