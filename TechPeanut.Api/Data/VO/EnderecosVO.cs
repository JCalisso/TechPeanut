using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.VO
{
    public class EnderecosVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        
        public string Endereco {  get; set; }

        public string Bairro { get; set; }

        public string NO_Endereco { get; set; }

        public string Observacao { get; set; }

        public string CEP { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
