using Microsoft.Extensions.Diagnostics.HealthChecks;
using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;

namespace TechPeanut.Api.Data.VO
{
    public class TelefonesVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Telefone { get; set; }

        public string ST_Tipo_Telefone { get; set; }

        public int ID_Pessoa { get; set; }

        public string SN_Principal { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
