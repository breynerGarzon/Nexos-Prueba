using System.Collections.Generic;
using WebApi.Modelo.Modelos;

namespace WebApi.Modelo.Entidades
{
    public class Doctor:UsuarioBase
    {
        public int NumeroCredencial { get; set; }
        // public string Direccion { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<PacientesDoctores> PacientesDoctores { get; set; }
        public List<DoctoresEspecialidades> DoctoresEspecialidades { get; set; }
    }
}