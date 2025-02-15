﻿namespace bpfull_shared.Model.Contato;

/// <summary>
/// Model for Contato model.
/// </summary>
public class ContatoModel
{
    public string Id { get; set; }
    public string ClienteId { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}