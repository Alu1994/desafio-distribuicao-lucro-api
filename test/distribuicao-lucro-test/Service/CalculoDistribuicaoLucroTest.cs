using DistribuicaoLucro.CrossCutting;
using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucro;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador;
using DistribuicaoLucro.Service.Colaboradores;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DistribuicaoLucro.Test.Service
{
    public class CalculoDistribuicaoLucroTest
    {
        [Fact]
        public void TestCalculoDistribuicaoLucroTest()
        {
            List<Colaborador> listaColaboradores = new List<Colaborador>();
            Colaborador colaborador = new Colaborador {
                area = "Tecnologia",
                cargo = "Desenvolvedor",
                dataAdmissao = DateTime.Now.AddYears(-1),
                matricula = "000001",
                nome = "Matheus",
                salarioBruto = 1000.00
            };
            listaColaboradores.Add(colaborador);
            Mock<IColaboradores> mockIColaboradoresService = new Mock<IColaboradores>();
            mockIColaboradoresService.Setup(setup => setup.BuscarDadosColaboradores()).Returns(listaColaboradores);
            Mock<ICalculoDistribuicaoLucroColaborador> mockICalculoDistribuicaoLucroColaboradorService = new Mock<ICalculoDistribuicaoLucroColaborador>();
            mockICalculoDistribuicaoLucroColaboradorService.Setup(setup => setup.CalcularBonusColaboradorAnual(colaborador)).Returns(2000);
            CalculoDistribuicaoLucro calculoDistribuicaoLucroService = new CalculoDistribuicaoLucro(mockIColaboradoresService.Object, mockICalculoDistribuicaoLucroColaboradorService.Object);


            RetornoCalculoParticipacaoLucroColaboradores retornoDistribuicaoLucroController = calculoDistribuicaoLucroService.CalcularParticipacaoLucroColaboradores(2000000.00);


            mockIColaboradoresService.Verify(verify => verify.BuscarDadosColaboradores(), Times.Once);
            mockICalculoDistribuicaoLucroColaboradorService.Verify(verify => verify.CalcularBonusColaboradorAnual(colaborador), Times.Once);
            Assert.Equal(1998000, retornoDistribuicaoLucroController.saldoTotalDisponibilizado);
        }
    }
}