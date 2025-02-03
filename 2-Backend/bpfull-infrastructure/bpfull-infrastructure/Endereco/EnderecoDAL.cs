using bpfull_infrastructure.Base;
using bpfull_infrastructure.Data;
using bpfull_shared.Model.Endereco;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Text;

namespace bpfull_infrastructure.Endereco;

public class EnderecoDAL : BaseDAL, IEnderecoDAL
{
    #region [ CTOR ]
    public EnderecoDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    public async Task<string> Create(EnderecoModel requestModel)
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" DROP TABLE IF EXISTS #RowInserted ");
        sqlBuilder.AppendLine(" CREATE TABLE #RowInserted ");
        sqlBuilder.AppendLine(" ( ");
        sqlBuilder.AppendLine("     Id VARCHAR(36) ");
        sqlBuilder.AppendLine(" ); ");

        sqlBuilder.AppendLine(" INSERT INTO Endereco ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         ClienteId ");
        sqlBuilder.AppendLine("         , CEP ");
        sqlBuilder.AppendLine("         , Endereco ");
        sqlBuilder.AppendLine("         , Bairro ");
        sqlBuilder.AppendLine("         , Cidade ");
        sqlBuilder.AppendLine("         , Estado ");
        sqlBuilder.AppendLine("         , Pais ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");

        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @ClienteId ");
        sqlBuilder.AppendLine("         , @CEP ");
        sqlBuilder.AppendLine("         , @Endereco ");
        sqlBuilder.AppendLine("         , @Bairro ");
        sqlBuilder.AppendLine("         , @Cidade ");
        sqlBuilder.AppendLine("         , @Estado ");
        sqlBuilder.AppendLine("         , @Pais ");
        sqlBuilder.AppendLine("     )  ");

        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        dynamicParameters.Add("@ClienteId", requestModel.ClienteId, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@CEP", requestModel.CEP, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Endereco", requestModel.Endereco, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Bairro", requestModel.Bairro, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Cidade", requestModel.Cidade, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Estado", requestModel.Estado, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Pais", requestModel.Pais, DbType.AnsiString, ParameterDirection.Input);

        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}