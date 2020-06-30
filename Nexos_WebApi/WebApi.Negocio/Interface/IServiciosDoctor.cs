using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Negocio.Interface
{
    public interface IServiciosDoctores

    {
        ModeloRespuesta<int> CrearDoctor(View_Doctor nuevoPaciente);
        ModeloRespuesta<int> EditarDoctor(View_Doctor nuevoPaciente);
        ModeloRespuesta<int> EliminarDoctor(int IdPaciente);
        ModeloRespuesta<View_Doctor> ConsultarDoctorPorId(int IdPaciente);
        ModeloRespuesta<View_Doctor> ConsultarDoctores();
        ModeloRespuesta<Doctor> ValidarDatosDeEntrada(View_Doctor Paciente,TipoValidacion TipoValidacion);
    }
}