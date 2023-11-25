using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS_Fiap.Models
{
    [Table("Tbl_EfeitoColateral")]
    public class EfeitoColateral
    {
        [Column("Id"),Key(),Required]
        public int EfeitoId { get; set; }

        [Required, MaxLength(2000)]
        public string Efeito { get; set; }

    }
}
