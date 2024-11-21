using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("Telefones")]
    public class Telefones : BaseEntity
    {
        [Column("Telefone")]
        public string Telefone {  get; set; }

        [Column("ST_Tipo_Telefone")]
        public string ST_Tipo_Telefone {  get; set; }

        [Column("ID_Pessoa")]
        public int ID_Pessoa { get; set; }

        [Column("SN_Principal")]
        public string SN_Principal { get; set; }

    }
}
