using ValueObjectApi = DistribuicaoLucro.CrossCutting.ValueObject;
using System;
using Xunit;
using DistribuicaoLucro.CrossCutting.Enumeradores;
using DistribuicaoLucro.CrossCutting.Extensions;

namespace DistribuicaoLucro.Test.CrossCutting.ValueObject
{
    public class ColaboradorTest
    {
        [Fact]
        public void TestColaboradorRetornarPesoAreaAtuacao()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 3000.00
            };

            int pesoAreaAtuacao = colaborador.RetornarPesoAreaAtuacao();

            Assert.Equal(AreaAtuacao.Tecnologia.RetornarDefaultValue<AreaAtuacao>(), pesoAreaAtuacao);
        }


        [Fact]
        public void TestColaboradorRetornarPesoFaixaSalarialEstagio()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 800.00
            };

            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(998.00);

            Assert.Equal(1, pesoFaixaSalarial);
        }

        [Fact]
        public void TestColaboradorRetornarPesoFaixaSalarial_1()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 1000.00
            };

            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(998.00);

            Assert.Equal(1, pesoFaixaSalarial);
        }

        [Fact]
        public void TestColaboradorRetornarPesoFaixaSalarial_2()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 3000.00
            };

            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(998.00);

            Assert.Equal(2, pesoFaixaSalarial);
        }

        [Fact]
        public void TestColaboradorRetornarPesoFaixaSalarial_3()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 6000.00
            };

            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(998.00);

            Assert.Equal(3, pesoFaixaSalarial);
        }

        [Fact]
        public void TestColaboradorRetornarPesoFaixaSalarial_5()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-5),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 13000.00
            };

            int pesoFaixaSalarial = colaborador.RetornarPesoFaixaSalarial(998.00);

            Assert.Equal(5, pesoFaixaSalarial);
        }


        [Fact]
        public void TestColaboradorRetornarPesoTempoAdmissaoNovo()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now,
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 1000.00
            };

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();

            Assert.Equal(1, pesoTempoAdmissao);
        }

        [Fact]
        public void TestColaboradorRetornarPesoTempoAdmissao_1()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-1),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 1000.00
            };

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();

            Assert.Equal(1, pesoTempoAdmissao);
        }

        [Fact]
        public void TestColaboradorRetornarPesoTempoAdmissao_2()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-3),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 3000.00
            };

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();

            Assert.Equal(2, pesoTempoAdmissao);
        }

        [Fact]
        public void TestColaboradorRetornarPesoTempoAdmissao_3()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-6),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 6000.00
            };

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();

            Assert.Equal(3, pesoTempoAdmissao);
        }

        [Fact]
        public void TestColaboradorRetornarPesoTempoAdmissao_5()
        {
            ValueObjectApi.Colaborador colaborador = new ValueObjectApi.Colaborador
            {
                area = "Tecnologia",
                cargo = "DBA",
                dataAdmissao = DateTime.Now.AddYears(-9),
                matricula = "028322",
                nome = "Romero Brito",
                salarioBruto = 13000.00
            };

            int pesoTempoAdmissao = colaborador.RetornarPesoTempoAdmissao();

            Assert.Equal(5, pesoTempoAdmissao);
        }
    }
}