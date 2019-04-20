using System.Collections.Generic;
using DistribuicaoLucro.CrossCutting;
using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador;
using DistribuicaoLucro.Service.Colaboradores;

namespace DistribuicaoLucro.Service.CalculoDistribuicaoLucro
{
    public class CalculoDistribuicaoLucro : ICalculoDistribuicaoLucro
    {
        private readonly IColaboradores _colaboradores;
        private readonly ICalculoDistribuicaoLucroColaborador _calculoDistribuicaoLucroColaborador;

        public CalculoDistribuicaoLucro(IColaboradores colaboradores, ICalculoDistribuicaoLucroColaborador calculoDistribuicaoLucroColaborador)
        {
            _colaboradores = colaboradores;
            _calculoDistribuicaoLucroColaborador = calculoDistribuicaoLucroColaborador;
        }

        public RetornoCalculoParticipacaoLucroColaboradores CalcularParticipacaoLucroColaboradores(double totalDisponibilizado)
        {
            var dadosColaboradores = _colaboradores.BuscarDadosColaboradores();
            RetornoCalculoParticipacaoLucroColaboradores calculoParticipacaoLucroColaboradores = new RetornoCalculoParticipacaoLucroColaboradores
            {
                totalDisponibilizado = totalDisponibilizado,
                saldoTotalDisponibilizado = totalDisponibilizado,
                totalFuncionarios = dadosColaboradores.Count,
                participacoes = new List<Participacao>()
            };

            foreach(Colaborador colaborador in dadosColaboradores)
            {
                var participacao = new Participacao
                {
                    matricula = colaborador.matricula,
                    nome = colaborador.nome
                };

                participacao.valorParticipacao = _calculoDistribuicaoLucroColaborador.CalcularBonusColaboradorAnual(colaborador);
                calculoParticipacaoLucroColaboradores.saldoTotalDisponibilizado -= participacao.valorParticipacao;
                calculoParticipacaoLucroColaboradores.totalDistribuido += participacao.valorParticipacao;

                calculoParticipacaoLucroColaboradores.participacoes.Add(participacao);
            }

            return calculoParticipacaoLucroColaboradores;
        }
    }
}