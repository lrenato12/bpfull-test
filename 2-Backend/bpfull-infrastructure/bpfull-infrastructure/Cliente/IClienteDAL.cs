using bpfull_shared.Model.Cliente;

namespace bpfull_infrastructure.Cliente;

public interface IClienteDAL
{
    Task<string> AddCliente(ClienteModel requestModel);
    Task<IEnumerable<ClienteModel>> GetAllCliente();
}