using OnceDev.Training.Api.Middleware;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException();

            app.UseMiddleware<CustomExceptionMiddleware>();
            return app;
        }
    }
}
