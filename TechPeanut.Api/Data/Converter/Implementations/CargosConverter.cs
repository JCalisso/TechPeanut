using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class CargosConverter : IParser<CargosVO, Cargos>, IParser<Cargos, CargosVO>
    {
        public Cargos Parse(CargosVO origin)
        {
            if (origin == null) return null;
            return new Cargos
            {
                Id = origin.Id,
                CD_Cargo = origin.CD_Cargo,
                NM_Cargo = origin.NM_Cargo,
                SN_Ativo = origin.SN_Ativo
            };
        }

        public CargosVO Parse(Cargos origin)
        {
            if (origin == null) return null;
            return new CargosVO
            {
                Id = origin.Id,
                CD_Cargo = origin.CD_Cargo,
                NM_Cargo = origin.NM_Cargo,
                SN_Ativo = origin.SN_Ativo
            };
        }

        public List<Cargos> Parse(List<CargosVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CargosVO> Parse(List<Cargos> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
