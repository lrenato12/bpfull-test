using Microsoft.AspNetCore.Mvc;

namespace bpfull_api.Controllers.Base;

/// <summary>
/// Classe base para controladores, fornecendo acesso a configurações e ambiente.
/// </summary>
[ApiController]
public class BaseController : ControllerBase
{
    #region Properties
    /// <summary>
    /// Configuração da aplicação.
    /// </summary>
    public readonly IConfiguration _configuration;

    /// <summary>
    /// Ambiente de hospedagem da aplicação.
    /// </summary>
    public readonly IWebHostEnvironment _environment;

    /// <summary>
    /// Acessor do contexto HTTP.
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Constructor
    /// <summary>
    /// Construtor que inicializa as dependências do controlador base.
    /// </summary>
    public BaseController([FromServices] IConfiguration configuration,
                          [FromServices] IWebHostEnvironment environment,
                          [FromServices] IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _environment = environment;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}