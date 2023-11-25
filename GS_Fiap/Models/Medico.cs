using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS_Fiap.Models
{
    [Table("Tbl_Medico")]
    public class Medico
    {
        [Column("Id")]
        public int MedicoId { get; set; }

        [Required, MaxLength(130)]
        public string Nome { get; set; }

        [Required, MaxLength(30)]
        public String Especialidade { get; set; }

        [Required, MaxLength(20)]
        public String CRM { get; set; }

        //N:M
        public IList<Consulta> Consultas { get; set; }

    }
}
