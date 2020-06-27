using System.Collections.Generic;
using WebApi.Modelo.Modelos;

namespace WebApi.Modelo.Entidades
{
    public class Paciente:UsuarioBase
    {
        public string SeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public int Telefono { get; set; }
        public List<PacientesDoctores> PacientesDoctores { get; set; }
    }
}