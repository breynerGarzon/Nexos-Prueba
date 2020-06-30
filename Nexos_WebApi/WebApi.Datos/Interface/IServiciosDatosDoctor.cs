using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Datos.Interface
{
    public interface IServiciosDatosDoctor
    {
        ModeloRespuesta<int> CrearDoctor(Doctor nuevoPaciente);
        ModeloRespuesta<int> EditarDoctor(Doctor nuevoPaciente);
        ModeloRespuesta<int> EliminarDoctor(int IdPaciente);
        ModeloRespuesta<Doctor> ConsultarDoctorPorId(int IdPaciente);
        ModeloRespuesta<Doctor> ConsultarDoctores();
    }
}