using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("Cargos")]
    public class Cargos : BaseEntity
    {
        [Required]
        [Column("CD_Cargo")]
        public string CD_Cargo { get; set; }

        [Required]
        [Column("NM_Cargo")]
        public string NM_Cargo { get; set; }

        [Required]
        [Column("SN_Ativo")]
        public bool SN_Ativo { get; set; }
    }
}
