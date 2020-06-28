using Microsoft.EntityFrameworkCore;
using WebApi.Datos.Configuracion;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Contexto
{
    public class HospitalContexto : DbContext
    {
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<PacientesDoctores> PacientesDoctores { get; set; }
        public DbSet<DoctoresEspecialidades> DoctoresEspecialidades { get; set; }
        
        public HospitalContexto(DbContextOptions<HospitalContexto> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PacienteConfiguracion());
            modelBuilder.ApplyConfiguration(new EspecialidadConfiguracion());
            modelBuilder.ApplyConfiguration(new HospitalConfiguracion());
            modelBuilder.ApplyConfiguration(new DoctorConfiguracion());
            modelBuilder.ApplyConfiguration(new PacientesDoctoresConfiguracion());
            modelBuilder.ApplyConfiguration(new DoctoresEspecialidadesConfiguracion());
        }
    }
}