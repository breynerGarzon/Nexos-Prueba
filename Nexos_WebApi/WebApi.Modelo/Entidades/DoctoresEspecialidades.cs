namespace WebApi.Modelo.Entidades
{
    public class DoctoresEspecialidades
    {
        public int DoctorId { get; set; }
        public int EspecialidadId { get; set; }
        public Doctor Doctor { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}