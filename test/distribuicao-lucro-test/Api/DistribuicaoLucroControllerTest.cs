using DistribuicaoLucro.Api.Controllers;
using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucro;
using DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador;
using DistribuicaoLucro.Service.Colaboradores;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DistribuicaoLucro.Test.Api
{
    public class Colaboradores
    {
        [Fact]
        public void TestDistribuicaoLucroControllerGet200OK()
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
            DistribuicaoLucroController distribuicaoLucroController = new DistribuicaoLucroController(calculoDistribuicaoLucroService);

            var retornoDistribuicaoLucroController = distribuicaoLucroController.Get(20000);


            mockIColaboradoresService.Verify(verify => verify.BuscarDadosColaboradores(), Times.Once);
            mockICalculoDistribuicaoLucroColaboradorService.Verify(verify => verify.CalcularBonusColaboradorAnual(colaborador), Times.Once);
            Assert.Equal(18000.00, retornoDistribuicaoLucroController.Value.Retorno.saldoTotalDisponibilizado);
            Assert.Equal(System.Net.HttpStatusCode.OK, retornoDistribuicaoLucroController.Value.HttpStatus);
        }

        [Fact]
        public void TestDistribuicaoLucroControllerGetThrows400BadRequest()
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
            Exception exception = new Exception("Impossivel calcular os dados XPTO");
            mockICalculoDistribuicaoLucroColaboradorService.Setup(setup => setup.CalcularBonusColaboradorAnual(colaborador)).Throws(exception);

            CalculoDistribuicaoLucro calculoDistribuicaoLucroService = new CalculoDistribuicaoLucro(mockIColaboradoresService.Object, mockICalculoDistribuicaoLucroColaboradorService.Object);
            DistribuicaoLucroController distribuicaoLucroController = new DistribuicaoLucroController(calculoDistribuicaoLucroService);


            var retornoDistribuicaoLucroController = distribuicaoLucroController.Get(20000);


            mockIColaboradoresService.Verify(verify => verify.BuscarDadosColaboradores(), Times.Once);
            mockICalculoDistribuicaoLucroColaboradorService.Verify(verify => verify.CalcularBonusColaboradorAnual(colaborador), Times.Once);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, retornoDistribuicaoLucroController.Value.HttpStatus);
        }
    }
}