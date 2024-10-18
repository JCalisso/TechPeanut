using TechPeanut.Api.Repository.Login.Entity;

namespace TechPeanut.Api.Repository.Login.Interfaces
{
    public interface ILoginRepository<T> where T : LoginEntity
    {
        List<T> FindAll();
        bool ValidaAcesso(string E_Mail, string Senha);
    }
}
