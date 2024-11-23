using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface ICargosBusiness
    {
        CargosVO Create(CargosVO cargos);

        CargosVO FindById(int id);

        List<CargosVO> FindAll();

        CargosVO Update(CargosVO cargos);

        void Delete(int id);

    }
}
