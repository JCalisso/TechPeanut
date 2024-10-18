using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("pessoas")]
    public class Pessoas : BaseEntity
    {
        [Column("ID_Pessoa")]
        public int Id { get; set; }

        [Column("NM_Pessoa")]
        public string NM_Pessoa { get; set;}

        [Column("ST_Tipo_Pessoa")]
        public string ST_Tipo_Pessoa { get; set; }

        [Column("CD_Documento_Pessoa")]
        public string CD_Documento_Pessoa { get; set; }

        [Column("DT_Nascimento")]
        public DateTime DT_Nascimento { get; set; }

        [Column("ST_Genero")]
        public string ST_Genero { get; set; }
    }
}
