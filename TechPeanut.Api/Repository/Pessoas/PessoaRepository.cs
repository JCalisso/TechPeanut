using Microsoft.EntityFrameworkCore;
using TechPeanut.Api.Models.Base;
using TechPeanut.Api.Models.Context;
using TechPeanut.Api.Repository.Generic;
using TechPeanut.Api.Repository.Login.Entity;
using TechPeanut.Api.Repository.Login.Interfaces;

namespace TechPeanut.Api.Repository.Pessoas
{
    public class PessoasRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SQLContext _sqlContext;

        private DbSet<T> dataset;

        public PessoasRepository(SQLContext sqlContext)
        {
            _sqlContext = sqlContext;
            dataset = _sqlContext.Set<T>();

        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }


        public bool TelefonePessoa(int ID_Pessoa)
        {
            return dataset.Any(param => param.E_Mail.Equals(E_Mail) && param.Senha.Equals(Senha));
        }
    }
}
