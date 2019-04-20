using DistribuicaoLucro.CrossCutting.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class AplicacaoConfiguracao
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection services)
        {
            var config = new ConfiguracaoAplicacao
            {
                FirebasePath = configuration.GetSection("FirebasePath").Value
            };
            services.AddSingleton<IConfiguracaoAplicacao>(config);
        }
    }
}
