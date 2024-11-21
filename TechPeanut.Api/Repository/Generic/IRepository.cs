using System.Linq.Expressions;
using TechPeanut.Api.Models;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T FindById(int id);

        List<T> FindAll();

        T Update(T item);

        void Delete(int id);

        bool Exists(int id);
    }
}
