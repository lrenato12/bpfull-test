namespace bpfull_infrastructure.Data;

/// <summary>
/// Classe que implementa o padrão Unit of Work para gerenciar transações de banco de dados.
/// Implementa a interface <see cref="IUnitOfWork"/>.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    #region [ PROPERTIES ]
    private readonly DbSession _session;
    #endregion

    #region [ CONSTRUCTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="UnitOfWork"/>.
    /// </summary>
    /// <param name="session">A sessão do banco de dados a ser utilizada.</param>
    public UnitOfWork(DbSession session) => _session = session;
    #endregion

    #region [ BEGIN TRANSACTION ]
    /// <summary>
    /// Inicia uma nova transação na sessão do banco de dados.
    /// </summary>
    public void BeginTransaction() => _session.Transaction = _session?.Connection?.BeginTransaction();
    #endregion

    #region [ COMMIT ]
    /// <summary>
    /// Confirma as alterações realizadas na transação.
    /// </summary>
    public void Commit()
    {
        _session?.Transaction.Commit();
        Dispose();
    }
    #endregion

    #region [ ROLLBACK ]
    /// <summary>
    /// Reverte as alterações realizadas na transação.
    /// </summary>
    public void Rollback()
    {
        _session?.Transaction?.Rollback();
        Dispose();
    }
    #endregion

    #region [ DISPOSE ]
    /// <summary>
    /// Libera os recursos utilizados pela transação.
    /// </summary>
    public void Dispose() => _session?.Transaction?.Dispose();
    #endregion
}