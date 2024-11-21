using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechPeanut.Api.Models.Base;

namespace TechPeanut.Api.Models
{
    [Table("Endereco")]
    public class Enderecos : BaseEntity
    {
        [Required]
        [Column("Endereco")]
        public string Endereco { get; set; }

        [Required]
        [Column("Bairro")]
        public string Bairro { get; set; }

        [Required]
        [Column("NO_Endereco")]
        public string NO_Endereco { get; set; }

        [Column("Observacao")]
        public string Observacao { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

    }
}
