using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Modelo.Entidades;

namespace WebApi.Datos.Configuracion
{
    public class HospitalConfiguracion : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hospital> builder)
        {
            var Hospitales = new List<Hospital>();
            Hospitales.Add(new Hospital(){Id=1, Nombre="Hospital 1" });
            Hospitales.Add(new Hospital(){Id=2, Nombre="Hospital 2" });
            Hospitales.Add(new Hospital(){Id=3, Nombre="Hospital 3" });
            builder.HasData(Hospitales.ToArray());
        }
    }
}