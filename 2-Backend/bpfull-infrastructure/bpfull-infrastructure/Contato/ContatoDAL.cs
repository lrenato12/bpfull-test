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

public class ContatoDAL : BaseDAL, IContatoDAL
{
    #region [ CTOR ]
    public ContatoDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

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
        sqlBuilder.AppendLine("         ClienteId ");
        sqlBuilder.AppendLine("         , Email ");
        sqlBuilder.AppendLine("         , Telefone ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");

        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @ClienteId ");
        sqlBuilder.AppendLine("         , @Email ");
        sqlBuilder.AppendLine("         , @Telefone ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        dynamicParameters.Add("@ClienteId", requestModel.ClienteId, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Email", requestModel.Email, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Telefone", requestModel.Telefone, DbType.AnsiString, ParameterDirection.Input);

        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}