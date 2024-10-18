using TechPeanut.Api.Hypermedia;
using TechPeanut.Api.Hypermedia.Abstract;

namespace TechPeanut.Api.Data.VO
{
    public class LoginVO : ISupportsHyperMedia
    {
        public int Id { get; set; }

        public string E_Mail { get; set; }

        public string Senha { get; set; }

        public bool Valido { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
