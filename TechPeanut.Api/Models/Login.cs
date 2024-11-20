using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;
using TechPeanut.Api.Repository.Login.Entity;

namespace TechPeanut.Api.Models
{
    [Table("Emails")]
    public class Login : LoginEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("E_Mail")]
        public string E_Mail { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

    }
}
