namespace bpfull_infrastructure.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    #region [ PROPERTIES ]
    private readonly DbSession _session;
    #endregion

    #region [ CONSTRUCTOR ]
    public UnitOfWork(DbSession session) => _session = session;
    #endregion

    #region [ BEGIN TRANSACTION ]
    public void BeginTransaction() => _session.Transaction = _session?.Connection?.BeginTransaction();
    #endregion

    #region [ COMMIT ]
    public void Commit()
    {
        _session?.Transaction.Commit();

        Dispose();
    }
    #endregion

    #region [ ROLLBACK ]
    public void Rollback()
    {
        _session?.Transaction?.Rollback();

        Dispose();
    }
    #endregion

    #region [ DISPOSE ]
    public void Dispose() => _session?.Transaction?.Dispose();
    #endregion
}