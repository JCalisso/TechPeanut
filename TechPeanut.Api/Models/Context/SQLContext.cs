using Microsoft.EntityFrameworkCore;
using System;

namespace TechPeanut.Api.Models.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        //adicionar os dbset
        public DbSet<Pessoas> Pessoas { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}
