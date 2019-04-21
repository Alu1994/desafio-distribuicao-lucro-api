using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador;
using System;
using Xunit;

namespace DistribuicaoLucro.Test.Service
{
    public class CalculoDistribuicaoLucroColaboradorTest
    {
        [Fact]
        public void TestCalculoDistribuicaoLucroColaboradorTest()
        {
            Colaborador colaborador = new Colaborador {
                area = "Tecnologia",
                cargo = "Desenvolvedor",
                dataAdmissao = DateTime.Now.AddYears(-1),
                matricula = "0120232",
                nome = "Joseph",
                salarioBruto = 4000.00
            };
            CalculoDistribuicaoLucroColaborador calculoDistribuicaoLucroColaboradorService = new CalculoDistribuicaoLucroColaborador();

            double retornoCalculoDistribuicaoLucroColaboradorService = calculoDistribuicaoLucroColaboradorService.CalcularBonusColaboradorAnual(colaborador);

            Assert.Equal(72000.00, retornoCalculoDistribuicaoLucroColaboradorService);
        }
    }
}