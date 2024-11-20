using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


        public List<T> ValidaAcesso(string E_Mail, string Senha)
        {
            var Email = dataset.Where(param => param.E_Mail == E_Mail && param.Senha == Senha).ToList();

            return Email;
        }
    }
}