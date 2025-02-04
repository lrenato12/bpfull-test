using bpfull_shared.Model.Contato;

namespace bpfull_infrastructure.Contato;

/// <summary>
/// Interface para acesso a dados de contatos.
/// </summary>
public interface IContatoDAL
{
    /// <summary>
    /// Cria um novo contato.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do contato a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo a string do resultado da criação.</returns>
    Task<string> Create(ContatoModel requestModel);
}