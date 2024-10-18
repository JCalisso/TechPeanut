using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class LoginConverter : IParser<LoginVO, Login>, IParser<Login, LoginVO>
    {
        public Login Parse(LoginVO origin)
        {
            if (origin == null) return null;
            return new Login
            {
                Id = origin.Id,
                E_Mail = origin.E_Mail,
                Senha = origin.Senha
            };
        }

        public LoginVO Parse(Login origin)
        {
            if (origin == null) return null;
            return new LoginVO
            {
                Id = origin.Id,
                E_Mail = origin.E_Mail,
                Senha = origin.Senha
            };
        }

        public List<Login> Parse(List<LoginVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<LoginVO> Parse(List<Login> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
