using bpfull_infrastructure.Base;
using bpfull_infrastructure.Data;
using bpfull_shared.Model.Documento;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Text;

namespace bpfull_infrastructure.Documento;

/// <summary>
/// Classe que fornece métodos para acesso a dados de documentos.
/// Implementa a interface <see cref="IDocumentoDAL"/>.
/// </summary>
public class DocumentoDAL : BaseDAL, IDocumentoDAL
{
    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DocumentoDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Accessor para o contexto HTTP.</param>
    /// <param name="configuration">Configurações de aplicação.</param>
    /// <param name="environment">Ambiente de execução.</param>
    /// <param name="dbSession">Sessão de banco de dados (opcional).</param>
    public DocumentoDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    /// <summary>
    /// Cria um novo documento no banco de dados.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do documento a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o ID do documento criado.</returns>
    public async Task<string> Create(DocumentoModel requestModel)
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" DROP TABLE IF EXISTS #RowInserted ");
        sqlBuilder.AppendLine(" CREATE TABLE #RowInserted ");
        sqlBuilder.AppendLine(" ( ");
        sqlBuilder.AppendLine("     Id VARCHAR(36) ");
        sqlBuilder.AppendLine(" ); ");

        sqlBuilder.AppendLine(" INSERT INTO Documento ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         ClienteId, CPF, CNPJ ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" OUTPUT INSERTED.Id INTO #RowInserted ");
        sqlBuilder.AppendLine(" VALUES ");
        sqlBuilder.AppendLine("     ( ");
        sqlBuilder.AppendLine("         @ClienteId, @CPF, @CNPJ ");
        sqlBuilder.AppendLine("     )  ");
        sqlBuilder.AppendLine(" SELECT Id FROM #RowInserted ");

        // Adicionando parâmetros dinâmicos
        dynamicParameters.Add("@ClienteId", requestModel.ClienteId, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@CPF", requestModel.CPF, DbType.AnsiString, ParameterDirection.Input);
        dynamicParameters.Add("@CNPJ", requestModel.CNPJ, DbType.AnsiString, ParameterDirection.Input);

        // Executando a consulta e retornando o ID do documento criado
        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}