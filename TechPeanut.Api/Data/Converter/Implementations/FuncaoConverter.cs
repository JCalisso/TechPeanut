using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class FuncaoConverter : IParser<FuncaoVO, Funcao>, IParser<Funcao, FuncaoVO>
    {
        public Funcao Parse(FuncaoVO origin)
        {
            if (origin == null) return null;
            return new Funcao
            {
                Id = origin.Id,
                CD_Funcao = origin.CD_Funcao,
                NM_Funcao = origin.NM_Funcao,
                SN_Ativo = origin.SN_Ativo
            };
        }

        public FuncaoVO Parse(Funcao origin)
        {
            if (origin == null) return null;
            return new FuncaoVO
            {
                Id = origin.Id,
                CD_Funcao = origin.CD_Funcao,
                NM_Funcao = origin.NM_Funcao,
                SN_Ativo = origin.SN_Ativo
            };
        }

        public List<Funcao> Parse(List<FuncaoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<FuncaoVO> Parse(List<Funcao> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
