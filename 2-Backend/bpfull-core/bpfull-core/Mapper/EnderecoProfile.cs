using AutoMapper;
using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.Endereco;

namespace bpfull_core.Mapper;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<EnderecoModel, ClienteRequestModel>();
        CreateMap<ClienteRequestModel, EnderecoModel>();
    }
}