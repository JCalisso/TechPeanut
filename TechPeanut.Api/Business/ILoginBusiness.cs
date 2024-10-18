using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface ILoginBusiness
    {

        List<LoginVO> FindAll();

        bool ValidaAcesso(string E_Mail, string Senha);

    }
}
