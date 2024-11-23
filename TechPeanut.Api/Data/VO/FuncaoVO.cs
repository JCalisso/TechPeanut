using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;

namespace TechPeanut.Api.Data.VO
{
    public class FuncaoVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string CD_Funcao { get; set; }
        public string NM_Funcao { get; set; }
        public bool SN_Ativo { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
