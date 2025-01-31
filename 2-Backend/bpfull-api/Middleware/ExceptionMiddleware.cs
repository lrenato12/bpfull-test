using bpfull_shared.Model.System;
using System.Net;

namespace bpfull_api.Middleware;

public class ExceptionMiddleware
{
    #region Properties
    private readonly RequestDelegate _next;
    #endregion

    #region CTOR
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    #endregion

    #region InvokeAsync
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
            var erro = e.Message;

            await HandleRequestExceptionAsync(httpContext, e);
        }
    }
    #endregion

    #region HandleCustomExceptionAsync
    private Task HandleCustomExceptionAsync(HttpContext context, CustomExceptionModel ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        return context.Response.WriteAsync(ex.GetError().ObjectToJson());
    }
    #endregion

    #region HandleRequestExceptionAsync
    private Task HandleRequestExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(new ApiResultModel().WithError(e.Message + ' ' + e.StackTrace).ObjectToJson());
    }
    #endregion
}