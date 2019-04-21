using System.Collections.Generic;
using AutoMapper;
using DistribuicaoLucro.CrossCutting.ValueObject;
using DistribuicaoLucro.Repository.Colaboradores;
using DistribuicaoLucro.Repository.Entities;

namespace DistribuicaoLucro.Service.Colaboradores
{
    public class Colaboradores : IColaboradores
    {
        private readonly IColaboradoresRepository _repository;
        private readonly IMapper _mapper;

        public Colaboradores(IColaboradoresRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<Colaborador> BuscarDadosColaboradores()
        {
            var colaboradorEntity = _repository.Obter<ColaboradorEntity>();
            return _mapper.Map<List<ColaboradorEntity>, List<Colaborador>>(colaboradorEntity);
        }
    }
}