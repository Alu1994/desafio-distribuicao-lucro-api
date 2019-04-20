using System.Collections.Generic;

namespace DistribuicaoLucro.CrossCutting
{
    public class RetornoCalculoParticipacaoLucroColaboradores
    {
        public List<Participacao> participacoes { get; set; }
        public int totalFuncionarios { get; set; }
        public double totalDistribuido { get; set; }
        public double totalDisponibilizado { get; set; }
        public double saldoTotalDisponibilizado { get; set; }
    }
}
