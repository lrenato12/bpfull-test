using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;

namespace bpfull_core.Cliente;

/// <summary>
/// Interface para gerenciamento de clientes.
/// </summary>
public interface IClienteManager
{
    /// <summary>
    /// Cria um novo cliente com base no modelo de requisição fornecido.
    /// </summary>
    /// <param name="requestModel">Modelo de requisição contendo os dados do cliente.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o resultado da API.</returns>
    Task<ApiResultModel> Create(ClienteRequestModel requestModel);

    /// <summary>
    /// Obtém a lista de clientes.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o resultado da API.</returns>
    Task<ApiResultModel> Get();
}