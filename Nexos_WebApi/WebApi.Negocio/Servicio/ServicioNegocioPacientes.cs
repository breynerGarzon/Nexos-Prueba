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
    public class ServicioNegocioPacientes : IServiciosPacientes
    {
        private readonly IServiciosDatosPacientes ServiciosDatosPacientes;
        public ServicioNegocioPacientes(IServiciosDatosPacientes serviciosDatosPacientes)
        {
            this.ServiciosDatosPacientes = serviciosDatosPacientes;
        }
        public ModeloRespuesta<View_Paciente> ConsultarPacientes()
        {
            try
            {
                var consultaPacientes = this.ServiciosDatosPacientes.ConsultarPacientes();
                if (consultaPacientes.StatusCode == HttpStatusCode.OK)
                {
                    var pacientes = consultaPacientes.Data.Select(item => new View_Paciente()
                    {
                        Id = item.Id,
                        Nombres = item.Nombres,
                        Apellidos = item.Apellidos,
                        CodigoPostal = item.CodigoPostal,
                        SeguroSocial = item.SeguroSocial,
                        Telefono = item.Telefono
                    })
                                                            .ToList();
                    return AdministracionRespuesta.Pacientes_Consultados_OK(pacientes);
                }
                return AdministracionRespuesta.ConsultaPaciente_NOT_FOUND(consultaPacientes.Message);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.ConsultaPaciente_INTERNAL_ERROR(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<View_Paciente> ConsultarPacientePorId(int IdPaciente)
        {
            try
            {
                if (IdPaciente > Validar.VALOR_PERMITIDO)
                {
                    var consultaPaciente = this.ServiciosDatosPacientes.ConsultarPacientePorId(IdPaciente);
                    if (consultaPaciente.StatusCode == HttpStatusCode.OK)
                    {
                        var pacienteConsultado = consultaPaciente.Objeto;
                        var paciente = new View_Paciente()
                        {
                            Id = pacienteConsultado.Id,
                            Nombres = pacienteConsultado.Nombres,
                            Apellidos = pacienteConsultado.Apellidos,
                            CodigoPostal = pacienteConsultado.CodigoPostal,
                            SeguroSocial = pacienteConsultado.SeguroSocial,
                            Telefono = pacienteConsultado.Telefono
                        };
                        return AdministracionRespuesta.Paciente_Consultado_OK(paciente);
                    }
                    return AdministracionRespuesta.ConsultaPaciente_NOT_FOUND(consultaPaciente.Message);
                }
                return AdministracionRespuesta.ConsultaPaciente_NOT_FOUND(Mensajes_Pacientes.DATO_INVALIDO);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.ConsultaPaciente_INTERNAL_ERROR(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> CrearPaciente(View_Paciente nuevoPaciente)
        {
            try
            {
                var consultaValidacion = ValidarDatosDeEntrada(nuevoPaciente, TipoValidacion.Creacion);
                if (consultaValidacion.StatusCode == HttpStatusCode.OK)
                {
                    return this.ServiciosDatosPacientes.CrearPaciente(consultaValidacion.Objeto);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(consultaValidacion.Message);
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EditarPaciente(View_Paciente nuevoPaciente)
        {
            try
            {
                var consultaValidacion = ValidarDatosDeEntrada(nuevoPaciente, TipoValidacion.Edicion);
                if (consultaValidacion.StatusCode == HttpStatusCode.OK)
                {
                    return this.ServiciosDatosPacientes.EditarPaciente(consultaValidacion.Objeto);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(consultaValidacion.Message);
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EliminarPaciente(int IdPaciente)
        {
            try
            {
                if (IdPaciente > Validar.VALOR_PERMITIDO)
                {
                    return this.ServiciosDatosPacientes.EliminarPaciente(IdPaciente);
                }
                return AdministracionRespuesta.DatosInvalidos_Badrequest(Mensajes_Pacientes.DATO_INVALIDO);
            }
            catch (System.Exception)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Pacientes.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<Paciente> ValidarDatosDeEntrada(View_Paciente Paciente, TipoValidacion TipoValidacion)
        {
            try
            {
                if (TipoValidacion == TipoValidacion.Edicion)
                {
                    Validar.ValidarCampoNumerico(Paciente.Id);
                }
                else
                {
                    Paciente.Id = 0;
                }
                Validar.ValidarCampoNumerico(Paciente.Telefono);
                Validar.ValidarCampoTexto(Paciente.Nombres);
                Validar.ValidarCampoTexto(Paciente.Apellidos);
                Validar.ValidarCampoTexto(Paciente.SeguroSocial);
                Validar.ValidarCampoTexto(Paciente.CodigoPostal);
                var nuevopaciente = new Paciente()
                {
                    Id = Paciente.Id,
                    Nombres = Paciente.Nombres,
                    Apellidos = Paciente.Apellidos,
                    CodigoPostal = Paciente.CodigoPostal,
                    SeguroSocial = Paciente.SeguroSocial,
                    Telefono = Paciente.Telefono
                };
                return AdministracionRespuesta.ConsultaPaciente_Ok(nuevopaciente);
            }
            catch (ValidacionException ex)
            {
                return AdministracionRespuesta.Consulta_Paciente_NoHayDatos_NoRegistra(ex.Message);
            }
        }
    }
}