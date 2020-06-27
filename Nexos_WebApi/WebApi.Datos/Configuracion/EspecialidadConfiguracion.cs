using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class EspecialidadConfiguracion : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Especialidad> builder)
        {
            var Especialidades = new List<Especialidad>();
            Especialidades.Add(new Especialidad(){Id=1, Nombre="Especialidad 1" });
            Especialidades.Add(new Especialidad(){Id=2, Nombre="Especialidad 2" });
            Especialidades.Add(new Especialidad(){Id=3, Nombre="Especialidad 3" });
            Especialidades.Add(new Especialidad(){Id=4, Nombre="Especialidad 4" });
            builder.HasData(Especialidades.ToArray());
        }
    }
}