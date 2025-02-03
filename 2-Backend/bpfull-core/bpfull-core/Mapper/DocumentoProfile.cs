using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Documento;

namespace bpfull_core.Mapper;

public class DocumentoProfile : Profile
{
    public DocumentoProfile()
    {
        CreateMap<DocumentoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, DocumentoModel>();
    }
}