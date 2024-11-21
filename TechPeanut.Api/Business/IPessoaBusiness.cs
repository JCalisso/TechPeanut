using System.Linq.Expressions;
using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface IPessoaBusiness
    {
        PessoasVO Create(PessoasVO pessoas);

        PessoasVO FindById(int id);

        List<PessoasVO> FindAll();

        PessoasVO Update(PessoasVO pessoas);

        void Delete(int id);
    }
}
