using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseNumberChecker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NumberCheckerMiddleware>();
        }
        public static IApplicationBuilder UseToLower(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ToLowerMiddleware>();
        }

        public static IApplicationBuilder RequestTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestTimeMiddleware>();
        }

    }
}
