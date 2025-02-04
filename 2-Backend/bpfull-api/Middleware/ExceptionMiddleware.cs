using bpfull_shared.Model.System;
using System.Net;

namespace bpfull_api.Middleware;

/// <summary>
/// Middleware para tratamento de exceções em requisições HTTP.
/// </summary>
public class ExceptionMiddleware
{
    #region Properties
    private readonly RequestDelegate _next;
    #endregion

    #region CTOR
    /// <summary>
    /// Construtor que aceita um delegador de requisições para encadear o middleware.
    /// </summary>
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    #endregion

    #region InvokeAsync
    /// <summary>
    /// Método que processa a requisição e captura exceções.
    /// </summary>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (CustomExceptionModel ex)
        {
            await HandleCustomExceptionAsync(httpContext, ex);
        }
        catch (Exception e)
        {
            await HandleRequestExceptionAsync(httpContext, e);
        }
    }
    #endregion

    #region HandleCustomExceptionAsync
    /// <summary>
    /// Trata exceções personalizadas e retorna a resposta apropriada.
    /// </summary>
    private Task HandleCustomExceptionAsync(HttpContext context, CustomExceptionModel ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        return context.Response.WriteAsync(ex.GetError().ObjectToJson());
    }
    #endregion

    #region HandleRequestExceptionAsync
    /// <summary>
    /// Trata exceções gerais e retorna uma resposta de erro.
    /// </summary>
    private Task HandleRequestExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(new ApiResultModel().WithError(e.Message + ' ' + e.StackTrace).ObjectToJson());
    }
    #endregion
}