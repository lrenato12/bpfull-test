using bpfull_shared.Model.Cliente;
using bpfull_shared.Model.System;

namespace bpfull_core.Cliente;

public interface IClienteManager
{
    Task<ApiResultModel> Create(ClienteRequestModel requestModel);
    Task<ApiResultModel> Get();
}