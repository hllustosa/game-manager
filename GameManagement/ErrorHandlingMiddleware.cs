using GameManagement.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GameManagement
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errors = new List<ValidationError>();
            var code = (int)HttpStatusCode.InternalServerError;
            var exceptionDetails = String.Format("{0}: {1}\n{2}", ex.GetType().Name, ex.Message, ex.StackTrace);
            
            if (ex is GameManagerException)
            {
                GameManagerException gmException = ((GameManagerException)ex);
                code = gmException.Code;

                if (String.IsNullOrEmpty(gmException.ErrorMessage))
                {
                    errors = gmException.Errors;
                }
                else
                {
                    errors.Add(new ValidationError { ErrorMsg = gmException.ErrorMessage });
                }
            }
            else
            {
                errors.Add(new ValidationError { ErrorMsg = "Internal Server Error" });
            }

            var result = JsonConvert.SerializeObject(new { errors });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
