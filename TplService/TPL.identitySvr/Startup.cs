using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.identitySvr
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
             
                options.AddPolicy("default", builder => builder
                   .WithOrigins("<http://localhost:8081/>", "<http://localhost:8081>")
                      .AllowAnyMethod()
                         .AllowAnyHeader()
                               .AllowCredentials()
                 );
            });

            services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddInMemoryApiScopes(Config.GetApiScopes())
             .AddInMemoryApiResources(Config.GetAllApi())
             .AddInMemoryClients(Config.GetClients());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseCors("default");

        }
    }
}
