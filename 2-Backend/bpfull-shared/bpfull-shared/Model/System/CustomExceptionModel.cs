namespace bpfull_shared.Model.System;

/// <summary>
/// Representa uma exceção personalizada que encapsula um modelo de resultado da API (<see cref="ApiResultModel"/>).
/// </summary>
public class CustomExceptionModel : Exception
{
    #region [ PROPERTIES ]
    /// <summary>
    /// Obtém o modelo de resultado da API associado à exceção.
    /// </summary>
    public ApiResultModel ResultModel { get; private set; }
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="CustomExceptionModel"/> com um modelo de resultado da API.
    /// </summary>
    /// <param name="resultModel">O modelo de resultado da API a ser associado à exceção.</param>
    public CustomExceptionModel(ApiResultModel resultModel) => ResultModel = resultModel;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="CustomExceptionModel"/> com uma mensagem de erro.
    /// </summary>
    /// <param name="errorMessage">A mensagem de erro a ser associada ao modelo de resultado da API.</param>
    public CustomExceptionModel(string errorMessage) => ResultModel = new ApiResultModel().WithError(errorMessage);
    #endregion

    #region [ METHODS ]
    /// <summary>
    /// Obtém o modelo de resultado da API associado à exceção.
    /// </summary>
    /// <returns>O modelo de resultado da API contendo detalhes do erro.</returns>
    public ApiResultModel GetError() => ResultModel;
    #endregion
}