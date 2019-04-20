using System.ComponentModel;

namespace DistribuicaoLucro.CrossCutting.Enumeradores
{
    public enum AreaAtuacao
    {
        [DefaultValue(1)]
        [Description("Diretoria")]
        Diretoria,
        [DefaultValue(2)]
        [Description("Contabilidade")]
        Contabilidade,
        [DefaultValue(2)]
        [Description("Financeiro")]
        Financeiro,
        [DefaultValue(2)]
        [Description("Tecnologia")]
        Tecnologia,
        [DefaultValue(3)]
        [Description("Serviços Gerais")]
        ServicosGerais,
        [DefaultValue(5)]
        [Description("Relacionamento com o Cliente")]
        RelacionamentoCliente
    }
}