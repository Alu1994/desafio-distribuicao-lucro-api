using DistribuicaoLucro.CrossCutting.ValueObject;
using System;

namespace DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador
{
    public class CalculoDistribuicaoLucroColaborador : ICalculoDistribuicaoLucroColaborador
    {
        private readonly double _salarioMinimo = 998.00;

        public virtual double CalcularBonusColaboradorAnual(Colaborador colaborador)
        {
            double salarioBruto = colaborador.salarioBruto;
            DateTime dataAdmissao = colaborador.dataAdmissao;

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();
            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(_salarioMinimo);
            int pesoAreaAtuacao = colaborador.RetornarPesoAreaAtuacao();

            double valorTempoAdmissao = CalcularSalarioTempoAdmissao(salarioBruto, pesoTempoAdmissao);
            double valorAreaAtuacao = CalcularSalarioAreaAtuacao(salarioBruto, pesoAreaAtuacao);

            double valorTempoArea = valorTempoAdmissao + valorAreaAtuacao;

            return (valorTempoArea / pesoFaixaSalarial) * 12;
        }

        private double CalcularSalarioTempoAdmissao(double salarioBruto, int pesoTempoAdmissao) => salarioBruto * pesoTempoAdmissao;

        private double CalcularSalarioAreaAtuacao(double salarioBruto, int pesoAreaAtuacao) => salarioBruto * pesoAreaAtuacao;
    }
}