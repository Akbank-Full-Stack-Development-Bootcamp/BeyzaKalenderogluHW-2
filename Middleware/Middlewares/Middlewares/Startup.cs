using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Middlewares.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Middlewares", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/weatherforecast")
                {
                    await context.Response.WriteAsync("Weather Forecast list");
                }
                else
                {
                    //if URL does not include /weatherforecast move to next middleware
                    await next();
                }
            });

            /*
            app.MapWhen(
                context =>
                    context.Request.Method == "POST" &&
                    context.Request.Path == "/acount",
                config =>
                    config.Use(async (context,next) =>
                    await context.Response.WriteAsync("post / account"))
                );

            app.Map("/profile",
                config =>
                config.Use(async(context,next)=>
                    await context.Response.WriteAsync("user profile")
                )
            );*/


   
            app.UseNumberChecker();
            app.UseToLower();
            app.RequestTime();
         
            
        }

        private RequestDelegate async(object context)
        {
            throw new NotImplementedException();
        }
    }
}
