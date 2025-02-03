using bpfull_api.Controllers.Base;
using bpfull_core.Cliente;
using bpfull_shared.Model.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace bpfull_api.Controllers.Cliente;

[Route("[controller]")]
[ApiController]
public class ClienteController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IClienteManager _clienteManager;
    #endregion

    #region [ CTOR ]
    public ClienteController([FromServices] IConfiguration configuration
        , [FromServices] IWebHostEnvironment environment
        , [FromServices] IHttpContextAccessor httpContextAccessor
        , IClienteManager clienteManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _clienteManager = clienteManager;
    }
    #endregion

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] ClienteModel requestModel)
        => Ok(await _clienteManager.Create(requestModel));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
        => Ok(await _clienteManager.Get());
}