using DistribuicaoLucro.CrossCutting.Infra;
using DistribuicaoLucro.Repository.Entities;
using DistribuicaoLucro.Repository.FirebaseWrapper;
using System.Collections.Generic;

namespace DistribuicaoLucro.Repository.Colaboradores
{
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly string _firebasePath;
        private readonly string _collection = "colaboradores";

        public ColaboradoresRepository(IConfiguracaoAplicacao configuracaoAplicacao)
        {
            _firebasePath = configuracaoAplicacao.FirebasePath;
        }

        public List<TEntity> Obter<TEntity>() where TEntity : Entity
        {
            FirebaseDB firebaseDB = new FirebaseDB(_firebasePath);
            FirebaseDB firebaseDBTeams = firebaseDB.Node(_collection);
            FirebaseResponse getResponse = firebaseDBTeams.Get();

            if (getResponse.Success)
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TEntity>>(getResponse.JSONContent);
            return new List<TEntity>();
        }
    }
}