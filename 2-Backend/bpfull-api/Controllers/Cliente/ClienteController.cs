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
    [Route("AddCliente")]
    public async Task<IActionResult> AddCliente([FromBody] ClienteModel requestModel)
        => Ok(await _clienteManager.AddCliente(requestModel));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var list = new List<ClienteModel>();

        list.Add(new ClienteModel
        {
            Nome = "Name",
            Email = "teste"
        });

        return Ok(list);
    }
}