using System;
using DistribuicaoLucro.CrossCutting;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucro;
using Microsoft.AspNetCore.Mvc;
using DistribuicaoLucro.CrossCutting.Infra;
using System.Net;

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

        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("{valorTotalDisponibilizado}")]
        [Produces("application/json", "application/xml")]
        public ActionResult<RetornoApi<RetornoCalculoParticipacaoLucroColaboradores>> Get(double valorTotalDisponibilizado)
        {
            var retornoApi = new RetornoApi<RetornoCalculoParticipacaoLucroColaboradores>();
            try
            {
                retornoApi.Retorno = _calculoDistribuicaoLucro.CalcularParticipacaoLucroColaboradores(valorTotalDisponibilizado);
                retornoApi.Message = "Dados gerados com sucesso!";
                retornoApi.HttpStatus = HttpStatusCode.OK;
                if(this.HttpContext != null)
                    this.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                retornoApi.Retorno = null;
                retornoApi.Message = $"Message: {ex.Message} {Environment.NewLine} {ex.StackTrace} {Environment.NewLine} {ex.InnerException}";
                retornoApi.HttpStatus = HttpStatusCode.BadRequest;
                if (this.HttpContext != null)
                    this.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return retornoApi;
        }
    }
}