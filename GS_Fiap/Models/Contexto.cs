using Microsoft.EntityFrameworkCore;

namespace GS_Fiap.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<EfeitoColateral> Efeitos { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Minha tabela Associativa
            modelBuilder.Entity<Consulta>()
                .HasKey(valor => new { valor.PacienteId, valor.MedicoId });

            //COnfiguração da minha tabela do paciente com a minha tabela de consulta
            modelBuilder.Entity<Consulta>()
                .HasOne(chave => chave.Paciente)
                .WithMany(chave => chave.Consultas)
                .HasForeignKey(chave => chave.PacienteId);

            //Configura da minha tabela do médico com a minha tabela de consulta
            modelBuilder.Entity<Consulta>()
               .HasOne(chave => chave.Medico)
               .WithMany(chave => chave.Consultas)
               .HasForeignKey(chave => chave.MedicoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
