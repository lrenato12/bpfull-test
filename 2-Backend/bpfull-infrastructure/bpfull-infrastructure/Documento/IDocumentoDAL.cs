using bpfull_shared.Model.Documento;

namespace bpfull_infrastructure.Documento;

public interface IDocumentoDAL
{
    Task<string> Create(DocumentoModel requestModel);
}