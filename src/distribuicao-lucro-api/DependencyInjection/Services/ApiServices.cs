using DistribuicaoLucro.Service.CalculoDistribuicaoLucro;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador;
using DistribuicaoLucro.Service.Colaboradores;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class ApiServices
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IColaboradores, Colaboradores>();
            services.AddTransient<ICalculoDistribuicaoLucro, CalculoDistribuicaoLucro>();
            services.AddTransient<ICalculoDistribuicaoLucroColaborador, CalculoDistribuicaoLucroColaborador>();
        }
    }
}