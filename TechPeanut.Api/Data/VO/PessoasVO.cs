using Microsoft.Extensions.Diagnostics.HealthChecks;
using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;

namespace TechPeanut.Api.Data.VO
{
    public class PessoasVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string NM_Pessoa { get; set; }

        public string ST_Tipo_Pessoa { get; set; }

        public string CD_Documento_Pessoa { get; set; }

        public DateTime DT_Nascimento { get; set; }

        public string ST_Genero { get; set; }

        public int? ID_Telefone_Principal { get; set; }

        public int? ID_Funcao { get; set; }

        public int? ID_Cargo {  get; set; }

        public int? ID_Dados_Bancarios { get; set; }

        public int? ID_Endereco {  get; set; }   

        public TelefonesVO Telefones { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
