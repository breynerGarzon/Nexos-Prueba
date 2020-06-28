using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Negocio.Interface
{
    public interface IServiciosDoctores

    {
        ModeloRespuesta<string> CrearDoctor(View_Doctor nuevoPaciente);
        ModeloRespuesta<string> EditarDoctor(View_Doctor nuevoPaciente);
        ModeloRespuesta<string> EliminarDoctor(int IdPaciente);
        ModeloRespuesta<View_Doctor> ConsultarDoctorPorId(int IdPaciente);
        ModeloRespuesta<View_Doctor> ConsultarDoctores();
        ModeloRespuesta<Doctor> ValidarDatosDeEntrada(View_Doctor Paciente,TipoValidacion TipoValidacion);
    }
}