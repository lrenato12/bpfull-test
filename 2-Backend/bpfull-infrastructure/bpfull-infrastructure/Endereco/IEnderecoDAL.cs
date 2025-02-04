using bpfull_shared.Model.Endereco;

namespace bpfull_infrastructure.Endereco;

/// <summary>
/// Interface para acesso a dados de endereços.
/// </summary>
public interface IEnderecoDAL
{
    /// <summary>
    /// Cria um novo endereço.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do endereço a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo a string do resultado da criação.</returns>
    Task<string> Create(EnderecoModel requestModel);
}