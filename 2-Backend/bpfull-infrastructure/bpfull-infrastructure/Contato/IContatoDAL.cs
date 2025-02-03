using bpfull_shared.Model.Contato;

namespace bpfull_infrastructure.Contato;

public interface IContatoDAL
{
    Task<string> Create(ContatoModel requestModel);
}