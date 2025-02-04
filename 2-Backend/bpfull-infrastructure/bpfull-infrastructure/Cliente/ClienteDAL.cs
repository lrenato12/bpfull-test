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

/// <summary>
/// Classe que fornece métodos para acesso a dados de clientes.
/// Implementa a interface <see cref="IClienteDAL"/>.
/// </summary>
public class ClienteDAL : BaseDAL, IClienteDAL
{
    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ClienteDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Accessor para o contexto HTTP.</param>
    /// <param name="configuration">Configurações de aplicação.</param>
    /// <param name="environment">Ambiente de execução.</param>
    /// <param name="dbSession">Sessão de banco de dados (opcional).</param>
    public ClienteDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
    }
    #endregion

    /// <summary>
    /// Cria um novo cliente no banco de dados.
    /// </summary>
    /// <param name="requestModel">Modelo de dados do cliente a ser criado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo o ID do cliente criado.</returns>
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

        // Executando a consulta e retornando o ID do cliente criado
        return await _dbSession.Connection.ExecuteScalarAsync<string>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }

    /// <summary>
    /// Recupera todos os clientes do banco de dados.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona, contendo uma coleção de modelos de resposta de clientes.</returns>
    public async Task<IEnumerable<ClienteResponseModel>> Get()
    {
        var sqlBuilder = new StringBuilder();
        var dynamicParameters = new DynamicParameters();

        sqlBuilder.AppendLine(" SELECT C.Id, C.Nome, CT.Email, CT.Telefone, ");
        sqlBuilder.AppendLine(" IIF(CPF IS NOT NULL AND LEN(CPF) = 11, ");
        sqlBuilder.AppendLine("     CONVERT(VARCHAR, STUFF(STUFF(STUFF(CPF, 4, 0, '.'), 8, 0, '.'), 12, 0, '-')), ");
        sqlBuilder.AppendLine("     IIF(CNPJ IS NOT NULL AND LEN(CNPJ) = 14, ");
        sqlBuilder.AppendLine("         CONVERT(VARCHAR, STUFF(STUFF(STUFF(STUFF(CNPJ, 3, 0, '.'), 7, 0, '.'), 11, 0, '/'), 16, 0, '-')), ");
        sqlBuilder.AppendLine("         NULL) ");
        sqlBuilder.AppendLine(" ) AS Documento, E.CEP, E.Endereco, E.Bairro, E.Cidade, E.Estado, E.Pais ");
        sqlBuilder.AppendLine(" FROM Cliente C ");
        sqlBuilder.AppendLine(" JOIN Contato CT ON CT.ClienteId = C.Id ");
        sqlBuilder.AppendLine(" JOIN Documento D ON D.ClienteId = C.Id ");
        sqlBuilder.AppendLine(" JOIN Endereco E ON E.ClienteId = C.Id ");

        // Executando a consulta e retornando a lista de clientes
        return await _dbSession.Connection.QueryAsync<ClienteResponseModel>(sqlBuilder.ToString(), dynamicParameters, transaction: _dbSession.Transaction);
    }
}