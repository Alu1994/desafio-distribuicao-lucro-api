using DistribuicaoLucro.CrossCutting;

namespace DistribuicaoLucro.Service.CalculoDistribuicaoLucro
{
    public interface ICalculoDistribuicaoLucro
    {
        RetornoCalculoParticipacaoLucroColaboradores CalcularParticipacaoLucroColaboradores(double totalDisponibilizado);
    }
}
