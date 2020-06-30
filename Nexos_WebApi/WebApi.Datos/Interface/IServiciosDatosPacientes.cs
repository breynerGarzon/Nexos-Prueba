using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Datos.Interface
{
    public interface IServiciosDatosPacientes
    {
        ModeloRespuesta<int> CrearPaciente(Paciente nuevoPaciente);
        ModeloRespuesta<int> EditarPaciente(Paciente nuevoPaciente);
        ModeloRespuesta<int> EliminarPaciente(int IdPaciente);
        ModeloRespuesta<Paciente> ConsultarPacientePorId(int IdPaciente);
        ModeloRespuesta<Paciente> ConsultarPacientes();
        ModeloRespuesta<int> RemoverRelacionDoctorPaciente(PacientesDoctores relacion);
        ModeloRespuesta<int> AgregarRelacionDoctorPaciente(PacientesDoctores relacion);
        ModeloRespuesta<ViewDoctorPaciente> ObtenerDoctorAsignados(int IdPaciente);
    }
}