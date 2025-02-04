using bpfull_shared.Model.Documento;

namespace bpfull_infrastructure.Documento;

/// <summary>
/// Interface para acesso a dados de documentos.
/// </summary>
public interface IDocumentoDAL
{
    /// <summary>
    /// Cria um novo documento.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do documento a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo a string do resultado da criação.</returns>
    Task<string> Create(DocumentoModel requestModel);
}