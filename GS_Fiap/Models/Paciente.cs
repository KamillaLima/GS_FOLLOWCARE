using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS_Fiap.Models
{
    [Table("Tbl_Paciente")]
    public class Paciente
    {
        [Column("Id")]
        public int PacienteId { get; set; }

        [Required, MaxLength(130)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required, MaxLength(40)]
        public String Senha { get; set; }

        [Required, MaxLength(11)]
        public String CPF { get; set; }

        //1:N
        public IList<Medicamento> Medicamentos { get; set; }

        //N:M
        public IList<Consulta> Consultas { get; set; }
    }
}
