using bpfull_shared.Model.Endereco;

namespace bpfull_infrastructure.Endereco;

public interface IEnderecoDAL
{
    Task<string> Create(EnderecoModel requestModel);
}