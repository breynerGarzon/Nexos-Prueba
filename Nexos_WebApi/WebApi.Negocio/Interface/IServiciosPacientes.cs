using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Negocio.Interface
{
    public interface IServiciosPacientes
    {
        ModeloRespuesta<string> CrearPaciente(View_Paciente nuevoPaciente);
        ModeloRespuesta<string> EditarPaciente(View_Paciente nuevoPaciente);
        ModeloRespuesta<string> EliminarPaciente(int IdPaciente);
        ModeloRespuesta<View_Paciente> ConsultarPacientePorId(int IdPaciente);
        ModeloRespuesta<View_Paciente> ConsultarPacientes();
        ModeloRespuesta<Paciente> ValidarDatosDeEntrada(View_Paciente Paciente,TipoValidacion TipoValidacion);
    }
}