using System.Collections.Generic;

namespace WebApi.Modelo.Entidades
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Doctor> Doctores { get; set; }
    }
}