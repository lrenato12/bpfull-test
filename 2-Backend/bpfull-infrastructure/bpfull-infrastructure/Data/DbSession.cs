using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace bpfull_infrastructure.Data;


/// <summary>
/// Manages a database session, including the connection and transaction lifecycle.
/// </summary>
public sealed class DbSession : IDisposable
{
    #region [ PROPERTIES ]
    private readonly IHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Gets the active database connection.
    /// </summary>
    public IDbConnection Connection { get; }

    /// <summary>
    /// Gets or sets the active database transaction.
    /// </summary>
    public IDbTransaction Transaction { get; set; }
    #endregion

    #region [ CONSTRUCTOR ]
    /// <summary>
    /// Initializes a new instance of the <see cref="DbSession"/> class.
    /// Opens the database connection using the connection string from the configuration.
    /// </summary>
    /// <param name="environment">Provides information about the host environment.</param>
    /// <param name="configuration">Provides application configuration values.</param>
    public DbSession(IHostEnvironment environment, IConfiguration configuration)
    {
        _environment = environment;
        _configuration = configuration;
        Connection = new SqlConnection(GetConnectionString());
        Connection.Open();
    }
    #endregion

    #region [ DISPOSE ]
    /// <summary>
    /// Disposes the database connection.
    /// </summary>
    public void Dispose() => Connection?.Dispose();
    #endregion

    #region [ GET CONNECTION STRING ]
    /// <summary>
    /// Retrieves the connection string from the application configuration.
    /// </summary>
    /// <returns>The connection string for the default database connection.</returns>
    private string? GetConnectionString() => _configuration.GetConnectionString("DefaultConnection");
    #endregion
}