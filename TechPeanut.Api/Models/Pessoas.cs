using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("pessoas")]
    public class Pessoas : BaseEntity
    {
        [Required]
        [Column("NM_Pessoa")]
        public string NM_Pessoa { get; set;}

        [Required]
        [Column("ST_Tipo_Pessoa")]
        public string ST_Tipo_Pessoa { get; set; }

        [Required]
        [Column("CD_Documento_Pessoa")]
        public string CD_Documento_Pessoa { get; set; }

        [Required]
        [Column("DT_Nascimento")]
        public DateTime DT_Nascimento { get; set; }

        [Required]
        [Column("ST_Genero")]
        public string ST_Genero { get; set; }

        [AllowNull]
        [Column("ID_Telefone_Principal")]
        public int? ID_Telefone_Principal { get; set; }

        [AllowNull]
        [Column("ID_Funcao")]
        public int? ID_Funcao { get; set; }

        [AllowNull]
        [Column("ID_Cargo")]
        public int? ID_Cargo { get; set; }

        [AllowNull]
        [Column("ID_Endereco")]
        public int? ID_Endereco { get; set; }

        [AllowNull]
        [Column("ID_Dados_Bancarios")]
        public int? ID_Dados_Bancarios { get; set; }

    }
}
