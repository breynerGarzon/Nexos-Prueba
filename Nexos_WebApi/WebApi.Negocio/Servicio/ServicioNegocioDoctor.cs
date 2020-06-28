using System.Linq;
using System.Net;
using WebApi.Datos.Interface;
using WebApi.Modelo.Entidades;
using WebApi.Modelo.Excepciones;
using WebApi.Modelo.Modelos;
using WebApi.Negocio.Interface;
using WebApi.Utilitario.AdministracionRespuestas;
using WebApi.Utilitario.Mensajes;
using WebApi.Utilitario.Validaciones;

namespace WebApi.Negocio.Servicio
{
    public class ServicioNegocioDoctor : IServiciosDoctores
    {
        private readonly IServiciosDatosDoctor ServiciosDatosDoctor;
        public ServicioNegocioDoctor(IServiciosDatosDoctor serviciosDatosPacientes)
        {
            this.ServiciosDatosDoctor = serviciosDatosPacientes;
        }
        public ModeloRespuesta<View_Doctor> ConsultarDoctores()
        {
            try
            {
                var consultaPacientes = this.ServiciosDatosDoctor.ConsultarDoctores();
                if (consultaPacientes.StatusCode == HttpStatusCode.OK)
                {
                    var doctores = consultaPacientes.Data.Select(item => new View_Doctor()
                    {
                        Id = item.Id,
                        Nombres = item.Nombres,
                        Apellidos = item.Apellidos,
                        HospitalId = item.HospitalId,
                        NumeroCredencial = item.NumeroCredencial
                    })
                                                            .ToList();
                    return AdministracionRespuesta.Doctores_Consultados_OK(doctores);
                }
                return AdministracionRespuesta.Consulta_Doctor_NOT_FOUND(consultaPacientes.Message);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.Consulta_Doctor_INTERNAL_ERROR(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<View_Doctor> ConsultarDoctorPorId(int IdPaciente)
        {
            try
            {
                if (IdPaciente > Validar.VALOR_PERMITIDO)
                {
                    var consultaPaciente = this.ServiciosDatosDoctor.ConsultarDoctorPorId(IdPaciente);
                    if (consultaPaciente.StatusCode == HttpStatusCode.OK)
                    {
                        var pacienteConsultado = consultaPaciente.Objeto;
                        var doctor = new View_Doctor()
                        {
                            Id = pacienteConsultado.Id,
                            Nombres = pacienteConsultado.Nombres,
                            Apellidos = pacienteConsultado.Apellidos,
                            NumeroCredencial = pacienteConsultado.NumeroCredencial,
                            HospitalId = pacienteConsultado.HospitalId,
                        };
                        return AdministracionRespuesta.Doctor_Consultado_OK(doctor);
                    }
                    return AdministracionRespuesta.Consulta_Doctor_NOT_FOUND(consultaPaciente.Message);
                }
                return AdministracionRespuesta.Consulta_Doctor_NOT_FOUND(Mensajes_Doctores.DATO_INVALIDO);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.Consulta_Doctor_INTERNAL_ERROR(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> CrearDoctor(View_Doctor nuevoDoctor)
        {
            try
            {
                var consultaValidacion = ValidarDatosDeEntrada(nuevoDoctor, TipoValidacion.Creacion);
                if (consultaValidacion.StatusCode == HttpStatusCode.OK)
                {
                    return this.ServiciosDatosDoctor.CrearDoctor(consultaValidacion.Objeto);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(consultaValidacion.Message);
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EditarDoctor(View_Doctor nuevoPaciente)
        {
            try
            {
                var consultaValidacion = ValidarDatosDeEntrada(nuevoPaciente, TipoValidacion.Edicion);
                if (consultaValidacion.StatusCode == HttpStatusCode.OK)
                {
                    return this.ServiciosDatosDoctor.EditarDoctor(consultaValidacion.Objeto);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(consultaValidacion.Message);
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EliminarDoctor(int IdPaciente)
        {
            try
            {
                if (IdPaciente > Validar.VALOR_PERMITIDO)
                {
                    return this.ServiciosDatosDoctor.EliminarDoctor(IdPaciente);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(Mensajes_Pacientes.DATO_INVALIDO);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<Doctor> ValidarDatosDeEntrada(View_Doctor Doctor, TipoValidacion TipoValidacion)
        {
            try
            {
                if (TipoValidacion == TipoValidacion.Edicion)
                {
                    Validar.ValidarCampoNumerico(Doctor.Id);
                }
                else
                {
                    Doctor.Id = 0;
                }
                Validar.ValidarCampoTexto(Doctor.Nombres);
                Validar.ValidarCampoTexto(Doctor.Apellidos);
                Validar.ValidarCampoNumerico(Doctor.NumeroCredencial);
                Validar.ValidarCampoNumerico(Doctor.HospitalId);
                var nuevoDoctor = new Doctor()
                {
                    Id = Doctor.Id,
                    Nombres = Doctor.Nombres,
                    Apellidos = Doctor.Apellidos,
                    NumeroCredencial = Doctor.NumeroCredencial,
                    HospitalId = Doctor.HospitalId,
                };
                return AdministracionRespuesta.ConsultaDoctor_Ok(nuevoDoctor);
            }
            catch (ValidacionException ex)
            {
                return AdministracionRespuesta.Consulta_Doctor_NoHayDatos_NoRegistra(ex.Message);
            }
        }
    }
}