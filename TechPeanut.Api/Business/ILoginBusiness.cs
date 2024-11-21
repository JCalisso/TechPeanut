using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface ILoginBusiness
    {
        List<LoginVO> FindAll();

        List<LoginVO> ValidaAcesso(string E_Mail, string Senha);
    }
}
