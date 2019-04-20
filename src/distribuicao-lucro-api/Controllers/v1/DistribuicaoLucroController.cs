using System;
using DistribuicaoLucro.CrossCutting;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucro;
using DistribuicaoLucro.CrossCutting.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace DistribuicaoLucro.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/DistribuicaoLucro")]
    [ApiController]
    public class DistribuicaoLucroController : ControllerBase
    {
        private readonly ICalculoDistribuicaoLucro _calculoDistribuicaoLucro;

        public DistribuicaoLucroController(ICalculoDistribuicaoLucro calculoDistribuicaoLucro)
        {
            _calculoDistribuicaoLucro = calculoDistribuicaoLucro;
        }

        [HttpGet("{valorTotalDisponibilizado}")]
        public ActionResult<RetornoCalculoParticipacaoLucroColaboradores> Get(double valorTotalDisponibilizado)
        {
            var colaborador = new Colaborador
            {
                matricula = "0005253",
                nome = "Wong Austin",
                area = "Financeiro",
                cargo = "Economista Júnior",
                salarioBruto = 2215.04,
                dataAdmissao = Convert.ToDateTime("2016-08-27")
            };

            return _calculoDistribuicaoLucro.CalcularParticipacaoLucroColaboradores(valorTotalDisponibilizado);
        }
    }
}