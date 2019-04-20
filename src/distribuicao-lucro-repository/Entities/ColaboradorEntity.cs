using System;

namespace DistribuicaoLucro.Repository.Entities
{
    public class ColaboradorEntity : Entity
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public double salarioBruto { get; set; }
        public DateTime dataAdmissao { get; set; }
    }
}
