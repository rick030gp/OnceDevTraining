using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<CustomExceptionMiddleware> logger)
        {            
            try
            {
                await _next(context);
            }
            
            catch (Exception ex)
            {
                switch (ex)
                {
                    case ArgumentNullException ag:
                        logger.LogError(ex, "ArgumentNullException");
                        break;
                    default:
                        var errorId = Guid.NewGuid();
                        logger.LogError(ex, $"Error with id: {errorId}");

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            errorId = errorId,
                            message = "Please contact technical support with the error Id."
                        }));
                        break;
                };                
            }
        }
    }
}
