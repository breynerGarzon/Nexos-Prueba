using System.Linq;
using System.Net;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using WebApi.Datos.Contexto;
using WebApi.Datos.Interface;
using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;
using WebApi.Utilitario.AdministracionRespuestas;
using WebApi.Utilitario.Mensajes;

namespace WebApi.Datos.Servicio
{
    public class ServicioDatosDoctor : IServiciosDatosDoctor
    {
        private readonly HospitalContexto Contexto;
        Logger Log;

        public ServicioDatosDoctor(HospitalContexto contexto)
        {
            this.Contexto = contexto;
        }
        public ModeloRespuesta<Doctor> ConsultarDoctores()
        {
            try
            {
                var doctores = this.Contexto.Doctores.ToList();
                return AdministracionRespuesta.DoctoresConsultado_OK(doctores);
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al consultar los doctores , "+ex);
                return AdministracionRespuesta.InternalErrorDoctor(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<Doctor> ConsultarDoctorPorId(int IdPaciente)
        {
            try
            {
                var doctor = this.Contexto.Doctores
                                                            .Where(pacienteTempo => pacienteTempo.Id == IdPaciente)
                                                            .FirstOrDefault();
                if (doctor != null)
                {
                    return AdministracionRespuesta.ConsultaDoctor_Ok(doctor);
                }
                else
                {
                    return AdministracionRespuesta.Consulta_Doctor_NoHayDatos_NoRegistra(Mensajes_Doctores.NO_EXISTE);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al consultar doctor por Id , "+ex);
                return AdministracionRespuesta.InternalErrorDoctor(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> CrearDoctor(Doctor nuevoDoctor)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    this.Contexto.Doctores.Add(nuevoDoctor);
                    var registros = this.Contexto.SaveChanges();
                    if (registros > 0)
                    {
                        transaccion.Commit();
                        return AdministracionRespuesta.CreacionExitosa_Ok(nuevoDoctor.Id);
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
                Log.Error("Error al crear doctor , "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> EditarDoctor(Doctor editarPaciente)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    var ConsultaDoctor = this.ConsultarDoctorPorId(editarPaciente.Id);
                    if (ConsultaDoctor.StatusCode == HttpStatusCode.OK)
                    {
                        var doctor = ConsultaDoctor.Objeto;
                        doctor.Nombres = editarPaciente.Nombres;
                        doctor.Apellidos = editarPaciente.Apellidos;
                        doctor.NumeroCredencial = editarPaciente.NumeroCredencial;
                        doctor.HospitalId = editarPaciente.HospitalId;
                        var registros = this.Contexto.SaveChanges();
                        if (registros > 0)
                        {
                            transaccion.Commit();
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(editarPaciente.Id);
                        }
                        else
                        {
                            transaccion.Rollback();
                            return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.EDICION_FALLIDA);
                        }
                    }
                    return AdministracionRespuesta.FinalizacionActividad_Fallida(ConsultaDoctor.Message);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al editar doctor , "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }

        public ModeloRespuesta<int> EliminarDoctor(int IdDoctor)
        {
            try
            {
                using (var transaccion = this.Contexto.Database.BeginTransaction())
                {
                    var ConsultaDoctor = this.ConsultarDoctorPorId(IdDoctor);
                    if (ConsultaDoctor.StatusCode == HttpStatusCode.OK)
                    {
                        var doctor = ConsultaDoctor.Objeto;
                        this.Contexto.Doctores.Remove(doctor);
                        var registros = this.Contexto.SaveChanges();
                        if (registros > 0)
                        {
                            transaccion.Commit();
                            return AdministracionRespuesta.FinalizacionActividad_Exitosa(IdDoctor);
                        }
                        else
                        {
                            transaccion.Rollback();
                            return AdministracionRespuesta.FinalizacionActividad_Fallida(Mensajes_Doctores.ELIMINACION_FALLIDA);
                        }
                    }
                    return AdministracionRespuesta.FinalizacionActividad_Fallida(ConsultaDoctor.Message);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error("Error al eliminar doctor , "+ex);
                return AdministracionRespuesta.InternalError(Mensajes_Doctores.INTERNAL_ERROR);
            }
        }
    }
}