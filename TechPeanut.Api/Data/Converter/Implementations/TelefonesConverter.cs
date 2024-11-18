using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class TelefonesConverter : IParser<TelefonesVO, Telefones>, IParser<Telefones, TelefonesVO>
    {
        public Telefones Parse(TelefonesVO origin)
        {
            if (origin == null) return null;
            return new Telefones
            {
                Id = origin.Id,
                Telefone = origin.Telefone,
                ST_Tipo_Telefone = origin.ST_Tipo_Telefone,
                ID_Pessoa = origin.ID_Pessoa,   
                SN_Principal = origin.SN_Principal
            };
        }

        public TelefonesVO Parse(Telefones origin)
        {
            if (origin == null) return null;
            return new TelefonesVO
            {
                Id = origin.Id,
                Telefone = origin.Telefone,
                ST_Tipo_Telefone = origin.ST_Tipo_Telefone,
                ID_Pessoa = origin.ID_Pessoa,
                SN_Principal = origin.SN_Principal
            };
        }

        public List<Telefones> Parse(List<TelefonesVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<TelefonesVO> Parse(List<Telefones> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
