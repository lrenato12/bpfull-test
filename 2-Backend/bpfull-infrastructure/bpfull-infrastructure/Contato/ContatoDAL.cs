using bpfull_infrastructure.Base;
using bpfull_infrastructure.Data;
using bpfull_shared.Model.Contato;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Text;

namespace bpfull_infrastructure.Contato;

/// <summary>
/// Classe que fornece métodos para acesso a dados de contatos.
/// Implementa a interface <see cref="IContatoDAL"/>.
/// </summary>
public class ContatoDAL : BaseDAL, IContatoDAL
{
    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ContatoDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Accessor para o contexto HTTP.</param>
    /// <param name="configuration">Configurações de aplicação.</param>
    /// <param name="environment">Ambiente de execução.</param>
    /// <param name="dbSession">Sessão de banco de dados (opcional).</param>
    public ContatoDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    /// <summary>
    /// Cria um novo contato no banco de dados.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do contato a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o ID do contato criado.</returns>
    public async Task<string> Create(ContatoModel requestModel)
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" DROP TABLE IF EXISTS #RowInserted ");
        sqlBuilder.AppendLine(" CREATE TABLE #RowInserted ");
        sqlBuilder.AppendLine(" ( ");
        sqlBuilder.AppendLine("     Id VARCHAR(36) ");
        sqlBuilder.AppendLine(" ); ");

        sqlBuilder.AppendLine(" INSERT INTO Contato ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         ClienteId, Email, Telefone ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");
        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @ClienteId, @Email, @Telefone ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        // Adicionando parâmetros dinâmicos
        dynamicParameters.Add("@ClienteId", requestModel.ClienteId, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Email", requestModel.Email, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Telefone", requestModel.Telefone, DbType.AnsiString, ParameterDirection.Input);

        // Executando a consulta e retornando o ID do contato criado
        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}