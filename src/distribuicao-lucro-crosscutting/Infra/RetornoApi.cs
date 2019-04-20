using System.Net;

namespace DistribuicaoLucro.CrossCutting.Infra
{
    public class RetornoApi<T>
    {
        public HttpStatusCode HttpStatus { get; set; }

        public T Retorno { get; set; }

        public string Message { get; set; }
    }
}