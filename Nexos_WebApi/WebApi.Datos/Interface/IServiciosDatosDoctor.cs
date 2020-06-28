using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Datos.Interface
{
    public interface IServiciosDatosDoctor
    {
        ModeloRespuesta<string> CrearDoctor(Doctor nuevoPaciente);
        ModeloRespuesta<string> EditarDoctor(Doctor nuevoPaciente);
        ModeloRespuesta<string> EliminarDoctor(int IdPaciente);
        ModeloRespuesta<Doctor> ConsultarDoctorPorId(int IdPaciente);
        ModeloRespuesta<Doctor> ConsultarDoctores();
    }
}