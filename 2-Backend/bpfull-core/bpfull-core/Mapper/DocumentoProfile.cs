using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Documento;

namespace bpfull_core.Mapper;

/// <summary>
/// Classe de perfil para mapeamento de objetos usando AutoMapper.
/// </summary>
public class DocumentoProfile : Profile
{
    /// <summary>
    /// Construtor que configura os mapeamentos entre DocumentoModel e ClienteRequestModel.
    /// </summary>
    public DocumentoProfile()
    {
        CreateMap<DocumentoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, DocumentoModel>();
    }
}