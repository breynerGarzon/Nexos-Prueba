using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Negocio.Interface
{
    public interface IServiciosPacientes
    {
        ModeloRespuesta<int> CrearPaciente(View_Paciente nuevoPaciente);
        ModeloRespuesta<int> EditarPaciente(View_Paciente nuevoPaciente);
        ModeloRespuesta<int> EliminarPaciente(int IdPaciente);
        ModeloRespuesta<View_Paciente> ConsultarPacientePorId(int IdPaciente);
        ModeloRespuesta<View_Paciente> ConsultarPacientes();
        ModeloRespuesta<Paciente> ValidarDatosDeEntrada(View_Paciente Paciente,TipoValidacion TipoValidacion);
        ModeloRespuesta<int> ActualizarRelacionDoctorPaciente(ViewDoctorPaciente SolicitudActualizacion);
        ModeloRespuesta<ViewDoctorPaciente> ObtenerDoctoresAsignados(int IdPaciente);
    }
}