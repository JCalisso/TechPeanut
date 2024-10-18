using TechPeanut.Api.Controllers;
using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;
using TechPeanut.Api.Repository.Login;
using TechPeanut.Api.Repository.Login.Interfaces;

namespace TechPeanut.Api.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private readonly ILoginRepository<Login> _repository;
        private readonly LoginConverter _converter;

        public LoginBusinessImplementation(ILoginRepository<Login> repository)
        {
            _repository = repository;
            _converter = new LoginConverter();
        }

        public List<LoginVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public bool ValidaAcesso(string E_Mail, string Senha)
        {
            return _repository.ValidaAcesso(E_Mail, Senha);
        }

    }
}
