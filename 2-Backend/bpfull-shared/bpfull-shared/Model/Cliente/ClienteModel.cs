﻿namespace bpfull_shared.Model.Cliente;

public class ClienteModel
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}