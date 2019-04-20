using DistribuicaoLucro.CrossCutting.ValueObject;
using System.Collections.Generic;

namespace DistribuicaoLucro.Service.Colaboradores
{
    public interface IColaboradores
    {
        List<Colaborador> BuscarDadosColaboradores();
    }
}