using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Datos.Interface
{
    public interface IServiciosDatosPacientes
    {
        ModeloRespuesta<string> CrearPaciente(Paciente nuevoPaciente);
        ModeloRespuesta<string> EditarPaciente(Paciente nuevoPaciente);
        ModeloRespuesta<string> EliminarPaciente(int IdPaciente);
        ModeloRespuesta<Paciente> ConsultarPacientePorId(int IdPaciente);
        ModeloRespuesta<Paciente> ConsultarPacientes();
    }
}