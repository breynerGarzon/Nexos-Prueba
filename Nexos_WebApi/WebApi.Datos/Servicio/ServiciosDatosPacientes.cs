using System.Linq;
using System.Net;
using Serilog.Core;
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
        Logger Log;
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
                Log.Error("Error al consltar paciente por Id"+ex);
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
                Log.Error("Error al consultar pacientes, "+ex);
                return AdministracionRespuesta.InternalErrorPacientes(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> CrearPaciente(Paciente nuevoPaciente)
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
                        return AdministracionRespuesta.CreacionExitosa_Ok(nuevoPaciente.Id);
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
                Log.Error("Error al crear paciente, "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> EditarPaciente(Paciente nuevoPaciente)
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
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(nuevoPaciente.Id);
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
                Log.Error("Error al editar paciente, "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> EliminarPaciente(int IdPaciente)
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
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(IdPaciente);
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
                Log.Error("Error al eliminar paciente, "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> RemoverRelacionDoctorPaciente(PacientesDoctores relacion)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    this.Contexto.PacientesDoctores.Remove(relacion);
                    var registros = this.Contexto.SaveChanges();
                    if (registros > 0)
                    {
                        transaccion.Commit();
                        return AdministracionRespuesta.CreacionExitosa_Ok(relacion.DoctorId);
                    }
                    else
                    {
                        transaccion.Rollback();
                        return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.AGREGAR_RELACIÒN_FALLIDA);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al remover el relacionamiento paciente - doctor, "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> AgregarRelacionDoctorPaciente(PacientesDoctores relacion)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    this.Contexto.PacientesDoctores.Add(relacion);
                    var registros = this.Contexto.SaveChanges();
                    if (registros > 0)
                    {
                        transaccion.Commit();
                        return AdministracionRespuesta.CreacionExitosa_Ok(relacion.DoctorId);
                    }
                    else
                    {
                        transaccion.Rollback();
                        return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.AGREGAR_RELACIÒN_FALLIDA);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al agregar el relacionamiento paciente - doctor, "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<ViewDoctorPaciente> ObtenerDoctorAsignados(int IdPaciente)
        {
            try
            {
                var doctoresAsignados = this.Contexto.PacientesDoctores.Where(item => item.PacienteId == IdPaciente)
                                                .Select(item => new ViewDoctorPaciente()
                                                {
                                                    DoctorId = item.DoctorId,
                                                    PacienteId = item.PacienteId
                                                }).ToList();
                if (doctoresAsignados != null && doctoresAsignados.Count != 0)
                {
                    return AdministracionRespuesta.Consulta_Ok(doctoresAsignados);
                }
                return AdministracionRespuesta.Consulta_NOFOUND(Mensajes_Doctores.NO_HAY_DATOS);
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al consultar los doctores asignados, "+ex);
                return AdministracionRespuesta.Consulta_INTERNAL_SERVER(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }
    }
}