using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class DoctorConfiguracion : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(s => s.Hospital)
            .WithMany(g => g.Doctores)
            .HasForeignKey(s => s.HospitalId);

            var Doctores = new List<Doctor>();
            Doctores.Add(new Doctor() { Id = 1, Nombres = "Doctor 1", Apellidos = "Pruebas 1", HospitalId = 1 });
            Doctores.Add(new Doctor() { Id = 2, Nombres = "Doctor 2", Apellidos = "Pruebas 2", HospitalId = 1 });
            Doctores.Add(new Doctor() { Id = 3, Nombres = "Doctor 3", Apellidos = "Pruebas 3", HospitalId = 1 });
            Doctores.Add(new Doctor() { Id = 4, Nombres = "Doctor 4", Apellidos = "Pruebas 4", HospitalId = 2 });
            Doctores.Add(new Doctor() { Id = 5, Nombres = "Doctor 5", Apellidos = "Pruebas 5", HospitalId = 2 });
            Doctores.Add(new Doctor() { Id = 6, Nombres = "Doctor 6", Apellidos = "Pruebas 6", HospitalId = 1 });
            Doctores.Add(new Doctor() { Id = 7, Nombres = "Doctor 7", Apellidos = "Pruebas 7", HospitalId = 3 });
            Doctores.Add(new Doctor() { Id = 8, Nombres = "Doctor 8", Apellidos = "Pruebas 8", HospitalId = 3 });
            Doctores.Add(new Doctor() { Id = 9, Nombres = "Doctor 9", Apellidos = "Pruebas 9", HospitalId = 3 });
            Doctores.Add(new Doctor() { Id = 10, Nombres = "Doctor 10", Apellidos = "Pruebas 10", HospitalId = 2 });
            Doctores.Add(new Doctor() { Id = 11, Nombres = "Doctor 11", Apellidos = "Pruebas 11", HospitalId = 1 });
            Doctores.Add(new Doctor() { Id = 12, Nombres = "Doctor 12", Apellidos = "Pruebas 12", HospitalId = 1 });
            builder.HasData(Doctores.ToArray());
        }
    }
}