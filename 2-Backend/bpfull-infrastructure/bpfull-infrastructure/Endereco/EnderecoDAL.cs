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

/// <summary>
/// Classe que fornece métodos para acesso a dados de endereços.
/// Implementa a interface <see cref="IEnderecoDAL"/>.
/// </summary>
public class EnderecoDAL : BaseDAL, IEnderecoDAL
{
    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="EnderecoDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Accessor para o contexto HTTP.</param>
    /// <param name="configuration">Configurações de aplicação.</param>
    /// <param name="environment">Ambiente de execução.</param>
    /// <param name="dbSession">Sessão de banco de dados (opcional).</param>
    public EnderecoDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    /// <summary>
    /// Cria um novo endereço no banco de dados.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do endereço a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o ID do endereço criado.</returns>
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
        sqlBuilder.AppendLine("         ClienteId, CEP, Endereco, Bairro, Cidade, Estado, Pais ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");
        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @ClienteId, @CEP, @Endereco, @Bairro, @Cidade, @Estado, @Pais ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        // Adicionando parâmetros dinâmicos
        dynamicParameters.Add("@ClienteId", requestModel.ClienteId, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@CEP", requestModel.CEP, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Endereco", requestModel.Endereco, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Bairro", requestModel.Bairro, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Cidade", requestModel.Cidade, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Estado", requestModel.Estado, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@Pais", requestModel.Pais, DbType.AnsiString, ParameterDirection.Input);

        // Executando a consulta e retornando o ID do endereço criado
        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}