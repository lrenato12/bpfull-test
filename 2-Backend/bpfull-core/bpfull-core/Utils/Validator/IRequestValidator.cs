using bpfull_shared.Model.System;

namespace bpfull_core.Utils.Validator;

/// <summary>
/// Interface genérica para validação de solicitações.
/// </summary>
/// <typeparam name="T">O tipo da solicitação a ser validada.</typeparam>
public interface IRequestValidator<T>
{
    /// <summary>
    /// Valida a solicitação fornecida e retorna um resultado da validação.
    /// </summary>
    /// <param name="request">A solicitação a ser validada.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> representando o resultado da validação.</returns>
    ApiResultModel ValidateRequest(T request);
}