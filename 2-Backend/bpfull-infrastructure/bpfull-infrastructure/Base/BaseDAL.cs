using bpfull_infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace bpfull_infrastructure.Base;

/// <summary>
/// Serves as the base class for Data Access Layer (DAL) implementations, 
/// providing common properties and dependencies for derived classes.
/// </summary>
public class BaseDAL
{
    #region [ PROPERTIES ]
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;

    /// <summary>
    /// Stores the roles of the current user.
    /// </summary>
    public readonly IEnumerable<string> _userRoles;

    /// <summary>
    /// Represents the database session used for managing connections and transactions.
    /// </summary>
    public readonly DbSession _dbSession;
    #endregion

    #region [ CONSTRUCTOR ]
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDAL"/> class.
    /// </summary>
    /// <param name="configuration">Provides application configuration values.</param>
    /// <param name="environment">Provides information about the host environment.</param>
    /// <param name="httpContextAccessor">Provides access to the current HTTP context, if needed.</param>
    /// <param name="dbSession">Optional parameter for managing database session and transactions.</param>
    public BaseDAL(IConfiguration configuration, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, DbSession dbSession = null)
    {
        _configuration = configuration;
        _environment = environment;
        _dbSession = dbSession;
    }
    #endregion

    #region [ METHODS ]
    // Common methods for data access can be added here in derived classes.
    #endregion
}