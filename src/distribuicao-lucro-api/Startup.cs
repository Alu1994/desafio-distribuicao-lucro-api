using DistribuicaoLucro.Api.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoLucro.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrap.ConfigureServices(Configuration, services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Bootstrap.Configure(app, env);
        }
    }
}