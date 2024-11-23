using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface IFuncaoBusiness
    {
        FuncaoVO Create(FuncaoVO funcao);

        FuncaoVO FindById(int id);

        List<FuncaoVO> FindAll();

        FuncaoVO Update(FuncaoVO funcao);

        void Delete(int id);

    }
}
