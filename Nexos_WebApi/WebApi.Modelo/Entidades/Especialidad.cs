using System.Collections.Generic;

namespace WebApi.Modelo.Entidades
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<DoctoresEspecialidades> DoctoresEspecialidades { get; set; }
    }
}