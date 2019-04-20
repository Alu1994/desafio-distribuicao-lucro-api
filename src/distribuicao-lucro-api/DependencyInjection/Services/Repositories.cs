using DistribuicaoLucro.Repository.Colaboradores;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class Repositories
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IColaboradoresRepository, ColaboradoresRepository>();
        }
    }
}
