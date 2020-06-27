namespace WebApi.Modelo.Entidades
{
    public class PacientesDoctores
    {
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
        public Doctor Doctor { get; set; }
        public Paciente Paciente { get; set; }
    }
}