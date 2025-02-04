namespace bpfull_infrastructure.Data;

/// <summary>
/// Interface que define um padrão Unit of Work para gerenciar transações de banco de dados.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Inicia uma nova transação.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Confirma as alterações realizadas na transação.
    /// </summary>
    void Commit();

    /// <summary>
    /// Reverte as alterações realizadas na transação.
    /// </summary>
    void Rollback();
}