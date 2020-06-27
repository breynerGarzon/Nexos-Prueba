using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class PacientesDoctoresConfiguracion : IEntityTypeConfiguration<PacientesDoctores>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PacientesDoctores> builder)
        {
            builder
                .HasKey(registro => new { registro.DoctorId, registro.PacienteId });
            builder
                .HasOne(bc => bc.Paciente)
                .WithMany(b => b.PacientesDoctores)
                .HasForeignKey(bc => bc.PacienteId);
            builder
                .HasOne(bc => bc.Doctor)
                .WithMany(c => c.PacientesDoctores)
                .HasForeignKey(bc => bc.DoctorId);

            builder.HasData(new[] {
                                    new {DoctorId = 1, PacienteId = 1},
                                    new {DoctorId = 2, PacienteId = 2},
                                    new {DoctorId = 2, PacienteId = 3},
                                    new {DoctorId = 1, PacienteId = 4},
                                    new {DoctorId = 4, PacienteId = 5},
                                    new {DoctorId = 4, PacienteId = 7},
                                    new {DoctorId = 5, PacienteId = 8},
                                    });
        }
    }
}