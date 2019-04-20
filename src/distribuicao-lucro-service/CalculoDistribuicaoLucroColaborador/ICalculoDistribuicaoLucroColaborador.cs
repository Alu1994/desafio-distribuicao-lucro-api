using DistribuicaoLucro.CrossCutting.ValueObject;

namespace DistribuicaoLucro.Service.CalculoDistribuicaoLucroColaborador
{
    public interface ICalculoDistribuicaoLucroColaborador
    {
        double CalcularBonusColaboradorAnual(Colaborador colaborador);
    }
}