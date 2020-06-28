using System.Linq;
using System.Net;
using WebApi.Datos.Contexto;
using WebApi.Datos.Interface;
using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;
using WebApi.Utilitario.AdministracionRespuestas;
using WebApi.Utilitario.Mensajes;

namespace WebApi.Datos.Servicio
{
    public class ServiciosDatosPacientes : IServiciosDatosPacientes
    {
        private readonly HospitalContexto Contexto;

        public ServiciosDatosPacientes(HospitalContexto contexto)
        {
            this.Contexto = contexto;
        }

        public ModeloRespuesta<Paciente> ConsultarPacientePorId(int IdPaciente)
        {
            try
            {
                var paciente = this.Contexto.Pacientes
                                                            .Where(pacienteTempo => pacienteTempo.Id == IdPaciente)
                                                            .FirstOrDefault();
                if (paciente != null)
                {
                    return AdministracionRespuesta.ConsultaPaciente_Ok(paciente);
                }
                else
                {
                    return AdministracionRespuesta.Consulta_Paciente_NoHayDatos_NoRegistra(Mensajes_Pacientes
                    .NO_EXISTE);
                }
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalErrorPacientes(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<Paciente> ConsultarPacientes()
        {
            try
            {
                var pacientes = this.Contexto.Pacientes.ToList();
                return AdministracionRespuesta.PacientesConsultados_OK(pacientes);
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalErrorPacientes(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> CrearPaciente(Paciente nuevoPaciente)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    this.Contexto.Pacientes.Add(nuevoPaciente);
                    var registros = this.Contexto.SaveChanges();
                    if (registros > 0)
                    {
                        transaccion.Commit();
                        return AdministracionRespuesta.CreacionExitosa_Ok(Mensajes_Doctores.CREACION_EXITOSA);
                    }
                    else
                    {
                        transaccion.Rollback();
                        return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.CREACION_FALLIDA);
                    }
                }
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EditarPaciente(Paciente nuevoPaciente)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    var ConsultaPaciente = this.ConsultarPacientePorId(nuevoPaciente.Id);
                    if (ConsultaPaciente.StatusCode == HttpStatusCode.OK)
                    {
                        var paciente = ConsultaPaciente.Objeto;
                        paciente.Nombres = nuevoPaciente.Nombres;
                        paciente.Apellidos = nuevoPaciente.Apellidos;
                        paciente.CodigoPostal = nuevoPaciente.CodigoPostal;
                        paciente.SeguroSocial = nuevoPaciente.SeguroSocial;
                        paciente.Telefono = nuevoPaciente.Telefono;
                        var registros = this.Contexto.SaveChanges();
                        if (registros > 0)
                        {
                            transaccion.Commit();
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(Mensajes_Doctores.EDICION_EXITOSA);
                        }
                        else
                        {
                            transaccion.Rollback();
                            return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.EDICION_FALLIDA);
                        }
                    }
                    return AdministracionRespuesta.FinalizacionActividad_Fallida(ConsultaPaciente.Message);
                }
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<string> EliminarPaciente(int IdPaciente)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    var ConsultaPaciente = this.ConsultarPacientePorId(IdPaciente);
                    if (ConsultaPaciente.StatusCode == HttpStatusCode.OK)
                    {
                        var paciente = ConsultaPaciente.Objeto;
                        this.Contexto.Pacientes.Remove(paciente);
                        var registros = this.Contexto.SaveChanges();
                        if (registros > 0)
                        {
                            transaccion.Commit();
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(Mensajes_Doctores.ELIMINACION_EXITOSA);
                        }
                        else
                        {
                            transaccion.Rollback();
                            return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.ELIMINACION_FALLIDA);
                        }
                    }
                    return AdministracionRespuesta.FinalizacionActividad_Fallida(ConsultaPaciente.Message);
                }
            }
            catch (System.Exception ex)
            {
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }
    }
}