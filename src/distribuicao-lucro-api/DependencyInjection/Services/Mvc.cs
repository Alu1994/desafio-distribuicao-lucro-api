using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class Mvc
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection services)
        {
            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
