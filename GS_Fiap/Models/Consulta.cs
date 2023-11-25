using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GS_Fiap.Models
{
    [Table("Tbl_Consulta")]
    public class Consulta
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }
    }
}
