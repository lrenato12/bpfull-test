using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Contato;

namespace bpfull_core.Mapper;

/// <summary>
/// Classe de perfil para mapeamento de objetos usando AutoMapper.
/// </summary>
public class ContatoProfile : Profile
{
    /// <summary>
    /// Construtor que configura os mapeamentos entre ContatoModel e ClienteRequestModel.
    /// </summary>
    public ContatoProfile()
    {
        CreateMap<ContatoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, ContatoModel>();
    }
}
