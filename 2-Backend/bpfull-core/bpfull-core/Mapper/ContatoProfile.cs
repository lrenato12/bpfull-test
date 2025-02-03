using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Contato;

namespace bpfull_core.Mapper;

public class ContatoProfile : Profile
{
    public ContatoProfile()
    {
        CreateMap<ContatoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, ContatoModel>();
    }
}
