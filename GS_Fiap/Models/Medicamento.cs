using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS_Fiap.Models
{
    [Table("Tbl_Medicamento")]
    public class Medicamento
    {
        [Column("Id")]
        public int MedicamentoId { get; set; }

        [Required, MaxLength(130)]
        public string Nome { get; set; }

        [Required, MaxLength(30)]
        public String Dosagem { get; set; }

        [Required, MaxLength(130)]
        public String Frequencia { get; set; }

        //N:1
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

        //1:1
        public EfeitoColateral EfeitoColateral { get; set; }
        public int EfeitoColateralId { get; set; }

    }
}
