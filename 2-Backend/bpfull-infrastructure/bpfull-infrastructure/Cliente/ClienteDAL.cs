using bpfull_infrastructure.Base;
using bpfull_infrastructure.Data;
using bpfull_shared.Model.Cliente;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Text;

namespace bpfull_infrastructure.Cliente;

public class ClienteDAL : BaseDAL, IClienteDAL
{
    #region [ CTOR ]
    public ClienteDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    public async Task<string> AddCliente(ClienteModel requestModel)
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" DROP TABLE IF EXISTS #RowInserted ");
        sqlBuilder.AppendLine(" CREATE TABLE #RowInserted ");
        sqlBuilder.AppendLine(" ( ");
        sqlBuilder.AppendLine("     Id VARCHAR(36) ");
        sqlBuilder.AppendLine(" ); ");

        sqlBuilder.AppendLine(" INSERT INTO Cliente ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         Nome ");
        sqlBuilder.AppendLine("         , Email ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");

        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @Nome ");
        sqlBuilder.AppendLine("         , @Email ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        dynamicParameters.Add("@Nome", requestModel.Nome, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Email", requestModel.Email, DbType.AnsiString, ParameterDirection.Input);

        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }

    public async Task<IEnumerable<ClienteModel>> GetAllCliente()
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" SELECT * FROM Cliente ");

        return await _dbSession.Connection.QueryAsync<ClienteModel>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}