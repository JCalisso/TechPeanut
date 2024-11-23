using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;

namespace TechPeanut.Api.Data.VO
{
    public class CargosVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string CD_Cargo { get; set; }
        public string NM_Cargo { get; set; }
        public bool SN_Ativo { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
