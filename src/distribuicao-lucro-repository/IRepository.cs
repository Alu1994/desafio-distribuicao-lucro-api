using System.Collections.Generic;

namespace DistribuicaoLucro.Repository
{
    public interface IRepository
    {
        List<TEntity> Obter<TEntity>() where TEntity : Entity;
    }
}