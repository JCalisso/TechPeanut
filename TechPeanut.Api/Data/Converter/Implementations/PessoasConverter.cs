using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class PessoasConverter : IParser<PessoasVO, Pessoas>, IParser<Pessoas, PessoasVO>
    {
        public Pessoas Parse(PessoasVO origin)
        {
            if (origin == null) return null;
            return new Pessoas
            {
                Id = origin.Id,
                NM_Pessoa = origin.NM_Pessoa,
                CD_Documento_Pessoa = origin.CD_Documento_Pessoa,
                DT_Nascimento = origin.DT_Nascimento,
                ST_Genero = origin.ST_Genero,
                ST_Tipo_Pessoa = origin.ST_Tipo_Pessoa
            };
        }

        public PessoasVO Parse(Pessoas origin)
        {
            if (origin == null) return null;
            return new PessoasVO
            {
                Id = origin.Id,
                NM_Pessoa = origin.NM_Pessoa,
                CD_Documento_Pessoa = origin.CD_Documento_Pessoa,
                DT_Nascimento = origin.DT_Nascimento,
                ST_Genero = origin.ST_Genero,
                ST_Tipo_Pessoa = origin.ST_Tipo_Pessoa
            };
        }

        public List<Pessoas> Parse(List<PessoasVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PessoasVO> Parse(List<Pessoas> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
