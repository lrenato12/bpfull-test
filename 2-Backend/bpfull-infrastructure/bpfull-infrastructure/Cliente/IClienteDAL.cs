using bpfull_shared.Model.Cliente;

namespace bpfull_infrastructure.Cliente;

public interface IClienteDAL
{
    Task<string> Create(ClienteModel requestModel);
    Task<IEnumerable<ClienteModel>> Get();
}