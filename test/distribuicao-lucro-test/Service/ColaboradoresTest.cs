using AutoMapper;
using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Repository.Colaboradores;
using DistribuicaoLucro.Repository.Entities;
using DistribuicaoLucro.Service.Colaboradores;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DistribuicaoLucro.Test.Service
{
    public class ColaboradoresTest
    {
        [Fact]
        public void TestColaboradores()
        {
            ColaboradorEntity colaboradorEntity = new ColaboradorEntity {
                area = "Financeiro",
                cargo = "?",
                dataAdmissao = DateTime.Now.AddYears(-1),
                matricula = "0218282",
                nome = "Ana Clara Pimenta",
                salarioBruto = 4000.00
            };
            List<ColaboradorEntity> listaColaboradoresEntity = new List<ColaboradorEntity>();
            listaColaboradoresEntity.Add(colaboradorEntity);

            Mock<IColaboradoresRepository> mockIColaboradoresRepository = new Mock<IColaboradoresRepository>();
            mockIColaboradoresRepository.Setup(setup => setup.Obter<ColaboradorEntity>()).Returns(listaColaboradoresEntity);

            Colaborador colaborador = new Colaborador {
                area = "Financeiro",
                cargo = "?",
                dataAdmissao = DateTime.Now.AddYears(-1),
                matricula = "0218282",
                nome = "Ana Clara Pimenta",
                salarioBruto = 4000.00
            };
            List<Colaborador> listaColaboradores = new List<Colaborador>();
            listaColaboradores.Add(colaborador);
            
            Mock<IMapper> mockIMapper = new Mock<IMapper>();
            mockIMapper.Setup(setup => setup.Map<List<ColaboradorEntity>, List<Colaborador>>(listaColaboradoresEntity)).Returns(listaColaboradores);

            Colaboradores colaboradoresService = new Colaboradores(mockIColaboradoresRepository.Object, mockIMapper.Object);


            List<Colaborador> colaboradores = colaboradoresService.BuscarDadosColaboradores();


            Assert.Equal(4000.00, colaboradores[0].salarioBruto);
            Assert.Equal("Ana Clara Pimenta", colaboradores[0].nome);
            mockIColaboradoresRepository.Verify(verify => verify.Obter<ColaboradorEntity>(), Times.Once);
        }
    }
}