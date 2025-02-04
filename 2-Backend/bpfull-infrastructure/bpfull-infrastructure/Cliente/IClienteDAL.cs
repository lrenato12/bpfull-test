using bpfull_shared.Model.Cliente;

namespace bpfull_infrastructure.Cliente;

/// <summary>
/// Interface para acesso a dados de clientes.
/// </summary>
public interface IClienteDAL
{
    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do cliente a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo a string do resultado da criação.</returns>
    Task<string> Create(ClienteModel requestModel);

    /// <summary>
    /// Recupera todos os clientes.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo uma coleção de modelos de resposta de clientes.</returns>
    Task<IEnumerable<ClienteResponseModel>> Get();
}