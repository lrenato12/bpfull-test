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

    public async Task<string> Create(ClienteModel requestModel)
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" DROP TABLE IF EXISTS #RowInserted ");
        sqlBuilder.AppendLine(" CREATE TABLE #RowInserted ");
        sqlBuilder.AppendLine(" ( ");
        sqlBuilder.AppendLine("     Id VARCHAR(36) ");
        sqlBuilder.AppendLine(" ); ");

        sqlBuilder.AppendLine(" INSERT INTO Cliente ( Nome ) ");
        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");
        sqlBuilder.AppendLine(" VALUES ( @Nome ) ");

        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        dynamicParameters.Add("@Nome", requestModel.Nome, DbType.AnsiString, ParameterDirection.Input);

        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }

    public async Task<IEnumerable<ClienteResponseModel>> Get()
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" SELECT C.Id ");
		sqlBuilder.AppendLine("         , C.Nome ");
		sqlBuilder.AppendLine("         , CT.Email ");
		sqlBuilder.AppendLine("         , CT.Telefone ");
        sqlBuilder.AppendLine("         , IIF(CPF IS NOT NULL AND LEN(CPF) = 11, ");
        sqlBuilder.AppendLine("             CONVERT(VARCHAR, ");
        sqlBuilder.AppendLine("                 STUFF(STUFF(STUFF(CPF, 4, 0, '.'), 8, 0, '.'), 12, 0, '-') ");
        sqlBuilder.AppendLine("             ), ");
        sqlBuilder.AppendLine("             IIF(CNPJ IS NOT NULL AND LEN(CNPJ) = 14, ");
        sqlBuilder.AppendLine("                 CONVERT(VARCHAR, ");
        sqlBuilder.AppendLine("                     STUFF(STUFF(STUFF(STUFF(CNPJ, 3, 0, '.'), 7, 0, '.'), 11, 0, '/'), 16, 0, '-') ");
        sqlBuilder.AppendLine("                 ), ");
        sqlBuilder.AppendLine("                 NULL) ");
        sqlBuilder.AppendLine("         ) AS Documento ");
        sqlBuilder.AppendLine("         , E.CEP ");
		sqlBuilder.AppendLine("         , E.Endereco ");
		sqlBuilder.AppendLine("         , E.Bairro ");
		sqlBuilder.AppendLine("         , E.Cidade ");
		sqlBuilder.AppendLine("         , E.Estado ");
		sqlBuilder.AppendLine("         , E.Pais ");
        sqlBuilder.AppendLine(" FROM Cliente C ");
        sqlBuilder.AppendLine(" JOIN Contato CT ON CT.ClienteId = C.Id ");
        sqlBuilder.AppendLine(" JOIN Documento D ON D.ClienteId = C.Id ");
        sqlBuilder.AppendLine(" JOIN Endereco E ON E.ClienteId = C.Id ");

        return await _dbSession.Connection.QueryAsync<ClienteResponseModel>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}