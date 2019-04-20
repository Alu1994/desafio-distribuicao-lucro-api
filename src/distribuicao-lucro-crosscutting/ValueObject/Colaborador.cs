using DistribuicaoLucro.CrossCutting.Enumeradores;
using DistribuicaoLucro.CrossCutting.Extensions;
using System;

namespace DistribuicaoLucro.CrossCutting.ValueObject
{
    public class Colaborador
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public double salarioBruto { get; set; }
        public DateTime dataAdmissao { get; set; }

        public int RetornarPesoTempoAdmissao()
        {
            DateTime dataAtual = DateTime.Now;
            if (dataAdmissao > dataAtual.AddYears(-1))
                return 1;
            else if (dataAdmissao > dataAtual.AddYears(-3))
                return 2;
            else if (dataAdmissao > dataAtual.AddYears(-8))
                return 3;
            else if (dataAdmissao < dataAtual.AddYears(-8))
                return 5;

            return 1;
        }

        public int RetornarPesoAreaAtuacao()
        {
            AreaAtuacao enumeradorAreaAtuacao = (AreaAtuacao)EnumExtensions.RetornarEnum<AreaAtuacao>(area);
            return (int)EnumExtensions.RetornarDefaultValue<AreaAtuacao>(enumeradorAreaAtuacao);
        }

        public int RetornarPesoFaixaSalarial(double salarioMinimo)
        {
            double pesoFaixaSalarial = (salarioBruto / salarioMinimo);

            if (pesoFaixaSalarial < 3)
                return 1;
            else if (pesoFaixaSalarial < 5)
                return 2;
            else if (pesoFaixaSalarial < 8)
                return 3;
            else if (pesoFaixaSalarial > 8)
                return 5;

            return 1;
        }
    }
}