using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Endereco;

namespace bpfull_core.Mapper;

/// <summary>
/// Classe de perfil para mapeamento de objetos usando AutoMapper.
/// </summary>
public class EnderecoProfile : Profile
{
    /// <summary>
    /// Construtor que configura os mapeamentos entre EnderecoModel e ClienteRequestModel.
    /// </summary>
    public EnderecoProfile()
    {
        CreateMap<EnderecoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, EnderecoModel>();
    }
}