using bpfull_api.Controllers.Base;
using bpfull_core.Cliente;
using bpfull_shared.Model.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace bpfull_api.Controllers.Cliente;

/// <summary>
/// Controlador para gerenciar operações relacionadas a clientes.
/// </summary>
[Route("[controller]")]
[ApiController]
public class ClienteController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IClienteManager _clienteManager;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Construtor para inicializar o ClienteController com suas dependências.
    /// </summary>
    public ClienteController([FromServices] IConfiguration configuration,
        [FromServices] IWebHostEnvironment environment,
        [FromServices] IHttpContextAccessor httpContextAccessor,
        IClienteManager clienteManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _clienteManager = clienteManager;
    }
    #endregion

    /// <summary>
    /// Cria um novo cliente com base no modelo de requisição fornecido.
    /// </summary>
    /// <param name="requestModel">Modelo de requisição para criação do cliente.</param>
    /// <returns>Resultado da operação de criação.</returns>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] ClienteRequestModel requestModel)
        => Ok(await _clienteManager.Create(requestModel));

    /// <summary>
    /// Obtém a lista de clientes.
    /// </summary>
    /// <returns>Lista de clientes.</returns>
    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
        => Ok(await _clienteManager.Get());
}