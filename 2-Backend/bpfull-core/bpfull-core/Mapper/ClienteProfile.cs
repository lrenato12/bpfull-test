using AutoMapper;
using bpfull_shared.Model.Cliente;

namespace bpfull_core.Mapper;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, ClienteModel>();
    }
}