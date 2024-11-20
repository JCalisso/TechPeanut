using System.ComponentModel.DataAnnotations.Schema;

namespace TechPeanut.Api.Repository.Login.Entity
{
    public class LoginEntity
    {
        [Column("E_Mail")]
        public string E_Mail { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("ID_Pessoa")]
        public int ID_Pessoa { get; set; }
    }
}
