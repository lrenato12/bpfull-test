﻿namespace bpfull_shared.Model.Cliente;

/// <summary>
/// Model for Cliente request model.
/// </summary>
public class ClienteRequestModel
{
    public string? ClienteId { get; set; }
    public string? ContatoId { get; set; }
    public string? DocumentoId { get; set; }
    public string? EnderecoId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? TipoDocumento { get; set; }
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }
    public string? CEP { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Pais { get; set; }
}