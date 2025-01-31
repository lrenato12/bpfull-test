using bpfull_api.Controllers.Base;
using bpfull_api.Model.Cliente;
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
    [Route("CreateGetTest")]
    public async Task<IActionResult> CreateGetTest()
    {
        return Ok("CreateGetTest - OK");
    }
}