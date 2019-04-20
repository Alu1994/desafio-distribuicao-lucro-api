using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DistribuicaoLucro.CrossCutting.DependencyInjection.Service
{
    public static class ApiVersioning
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddApiVersioning(o => {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(new DateTime(2019, 4, 19), 1, 0);
            });
        }
    }
}
