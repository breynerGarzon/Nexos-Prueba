using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class DoctoresEspecialidadesConfiguracion : IEntityTypeConfiguration<DoctoresEspecialidades>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DoctoresEspecialidades> builder)
        {
            builder
                .HasKey(registro => new { registro.DoctorId, registro.EspecialidadId });
            builder
                .HasOne(bc => bc.Especialidad)
                .WithMany(b => b.DoctoresEspecialidades)
                .HasForeignKey(bc => bc.EspecialidadId);
            builder
                .HasOne(bc => bc.Doctor)
                .WithMany(c => c.DoctoresEspecialidades)
                .HasForeignKey(bc => bc.DoctorId);
            builder.HasData(new[] {
                                    new {DoctorId = 1, EspecialidadId = 1},
                                    new {DoctorId = 1, EspecialidadId = 2},
                                    new {DoctorId = 1, EspecialidadId = 3},
                                    new {DoctorId = 1, EspecialidadId = 4},
                                    new {DoctorId = 2, EspecialidadId = 1},
                                    new {DoctorId = 2, EspecialidadId = 3},
                                    new {DoctorId = 2, EspecialidadId = 4},
                                    new {DoctorId = 3, EspecialidadId = 1},
                                    new {DoctorId = 3, EspecialidadId = 2},
                                    new {DoctorId = 4, EspecialidadId = 1},
                                    new {DoctorId = 4, EspecialidadId = 2},
                                    new {DoctorId = 4, EspecialidadId = 3},
                                    new {DoctorId = 5, EspecialidadId = 1},
                                    new {DoctorId = 5, EspecialidadId = 2},
                                    new {DoctorId = 5, EspecialidadId = 3},
                                    new {DoctorId = 6, EspecialidadId = 4},
                                    new {DoctorId = 7, EspecialidadId = 1},
                                    new {DoctorId = 7, EspecialidadId = 2},
                                    new {DoctorId = 8, EspecialidadId = 3}
                                    });
        }
    }
}