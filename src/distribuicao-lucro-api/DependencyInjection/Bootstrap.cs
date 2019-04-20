using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using DistribuicaoLucro.CrossCutting.DependencyInjection.Service;

namespace DistribuicaoLucro.Api.DependencyInjection
{
    public class Bootstrap
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            Mvc.ConfigureService(configuration, services);
            Swagger.ConfigureService(configuration, services);
            ApiVersioning.ConfigureService(services);
            services.AddAutoMapper();
            AplicacaoConfiguracao.ConfigureService(configuration, services);
            Repositories.ConfigureService(services);
            ApiServices.ConfigureService(services);
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            Swagger.Configure(app);
            Mvc.Configure(app);
        }
    }
}
