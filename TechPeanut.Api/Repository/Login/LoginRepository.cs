using Microsoft.EntityFrameworkCore;
using System.Data;
using TechPeanut.Api.Models.Base;
using TechPeanut.Api.Models.Context;
using TechPeanut.Api.Repository.Generic;
using TechPeanut.Api.Repository.Login.Entity;
using TechPeanut.Api.Repository.Login.Interfaces;

namespace TechPeanut.Api.Repository.Login
{
    public class LoginRepository<T> : ILoginRepository<T> where T : LoginEntity
    {
        private SQLContext _sqlContext;

        private DbSet<T> dataset;

        public LoginRepository(SQLContext sqlContext)
        {
            _sqlContext = sqlContext;
            dataset = _sqlContext.Set<T>();

        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }


        public bool ValidaAcesso(string E_Mail, string Senha)
        {
            return dataset.Any(param => param.E_Mail.Equals(E_Mail) && param.Senha.Equals(Senha));
        }
    }
}