using bpfull_api.Controllers.Base;
using bpfull_shared.Model.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace bpfull_api.Controllers.Cliente;

[Route("[controller]")]
[ApiController]
public class ClienteController : BaseController
{
    #region [ CTOR ]
    public ClienteController([FromServices] IConfiguration configuration, [FromServices] IWebHostEnvironment environment, [FromServices] IHttpContextAccessor httpContextAccessor)
        : base(configuration, environment, httpContextAccessor)
    {

    }
    #endregion

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] ClienteModel requestModel)
    {
        return Ok(new
        {
            id = "1",
            nome = "Name",
            email = "test@test.com"
        });
    }

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