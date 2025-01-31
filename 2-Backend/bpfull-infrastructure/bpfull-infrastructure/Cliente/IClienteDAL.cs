using bpfull_shared.Model.Cliente;

namespace bpfull_infrastructure.Cliente;

public interface IClienteDAL
{
    Task<int> AddCliente(ClienteModel requestModel);
    Task<IEnumerable<ClienteModel>> GetAllCliente();
}