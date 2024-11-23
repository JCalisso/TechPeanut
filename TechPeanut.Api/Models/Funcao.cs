using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("Funcao")]
    public class Funcao : BaseEntity
    {
        [Required]
        [Column("CD_Funcao")]
        public string CD_Funcao { get; set; }

        [Required]
        [Column("NM_Funcao")]
        public string NM_Funcao { get; set; }

        [Required]
        [Column("SN_Ativo")]
        public bool SN_Ativo { get; set; }
    }
}
