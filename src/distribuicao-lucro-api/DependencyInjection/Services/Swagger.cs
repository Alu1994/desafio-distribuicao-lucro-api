using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class Swagger
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Distribuição de Lucros", Version = "v1" });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Distribuição de Lucros");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
