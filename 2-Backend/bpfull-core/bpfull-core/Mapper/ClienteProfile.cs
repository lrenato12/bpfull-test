using AutoMapper;
using bpfull_shared.Model.Cliente;

namespace bpfull_core.Mapper;

/// <summary>
/// Classe de perfil para mapeamento de objetos usando AutoMapper.
/// </summary>
public class ClienteProfile : Profile
{
    /// <summary>
    /// Construtor que configura os mapeamentos entre ClienteModel e ClienteRequestModel.
    /// </summary>
    public ClienteProfile()
    {
        CreateMap<ClienteModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, ClienteModel>();
    }
}