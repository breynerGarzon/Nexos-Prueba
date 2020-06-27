using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class PacienteConfiguracion : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Paciente> builder)
        {
            var Pacientes = new List<Paciente>();
            Pacientes.Add(new Paciente(){Id=1, Nombres="Paciente 1", Apellidos="Pruebas 1", SeguroSocial="123456",Telefono=123456789 });
            Pacientes.Add(new Paciente(){Id=2, Nombres="Paciente 2", Apellidos="Pruebas 2", SeguroSocial="456789",Telefono=123456789 });
            Pacientes.Add(new Paciente(){Id=3, Nombres="Paciente 3", Apellidos="Pruebas 3", SeguroSocial="101112",Telefono=10111213 });
            Pacientes.Add(new Paciente(){Id=4, Nombres="Paciente 4", Apellidos="Pruebas 4", SeguroSocial="131415",Telefono=14151617 });
            Pacientes.Add(new Paciente(){Id=5, Nombres="Paciente 5", Apellidos="Pruebas 5", SeguroSocial="161718",Telefono=18192021 });
            Pacientes.Add(new Paciente(){Id=6, Nombres="Paciente 6", Apellidos="Pruebas 6", SeguroSocial="202122",Telefono=22232425 });
            Pacientes.Add(new Paciente(){Id=7, Nombres="Paciente 7", Apellidos="Pruebas 7", SeguroSocial="232425",Telefono=26272829 });
            Pacientes.Add(new Paciente(){Id=8, Nombres="Paciente 8", Apellidos="Pruebas 8", SeguroSocial="262728",Telefono=30313233 });
            Pacientes.Add(new Paciente(){Id=9, Nombres="Paciente 9", Apellidos="Pruebas 9", SeguroSocial="293031",Telefono=34353637 });
            Pacientes.Add(new Paciente(){Id=10, Nombres="Paciente 10", Apellidos="Pruebas 10", SeguroSocial="323334",Telefono=38394041 });
            Pacientes.Add(new Paciente(){Id=11, Nombres="Paciente 11", Apellidos="Pruebas 11", SeguroSocial="353637",Telefono=42434445 });
            Pacientes.Add(new Paciente(){Id=12, Nombres="Paciente 12", Apellidos="Pruebas 12", SeguroSocial="383940",Telefono=46474850 });
            builder.HasData(Pacientes.ToArray());
        }
    }
}