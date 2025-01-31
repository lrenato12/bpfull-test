using Microsoft.AspNetCore.Http;

namespace bpfull_core.Base;

public class BaseManager
{
    #region Properties
    /// <summary>
    /// Provides access to the current HTTP context.
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Claims
    // This section can be used for handling claims (user roles, permissions, etc.) if needed in the future.
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseManager"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Provides access to the current HTTP context.</param>
    public BaseManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}