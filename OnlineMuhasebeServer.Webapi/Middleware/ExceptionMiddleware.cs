using System;
using Microsoft.AspNetCore.Http;

namespace OnlineMuhasebeServer.Webapi.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync(new ErrorResult
            {

                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                TechnicalMessage = ex.InnerException == null ? ex.StackTrace : ex.InnerException.StackTrace
            }.ToString()) ;
        }
    }
}

