using System.Collections.Generic;
using System.Net;
using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;

namespace WebApi.Utilitario.AdministracionRespuestas
{
    public static class AdministracionRespuesta
    {
        public static ModeloRespuesta<string> CreacionExitosa_Ok(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.Created;
            respuesta.Message = Mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }


        public static ModeloRespuesta<Doctor> DoctoresConsultado_OK(IEnumerable<Doctor> Datos)
        {
            var respuesta = new ModeloRespuesta<Doctor>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = null;
            respuesta.Data = Datos;
            return respuesta;
        }

        public static ModeloRespuesta<Paciente> PacientesConsultados_OK(IEnumerable<Paciente> Datos)
        {
            var respuesta = new ModeloRespuesta<Paciente>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = null;
            respuesta.Data = Datos;
            return respuesta;
        }


        public static ModeloRespuesta<string> FinalizacionActividad_Exitosa(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = Mensaje;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<string> FinalizacionActividad_Fallida(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.BadRequest;
            respuesta.Message = null;
            respuesta.Objeto = Mensaje;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<string> DatosNoEncontrados(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.Created;
            respuesta.Message = null;
            respuesta.Objeto = Mensaje;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<string> InternalError(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.InternalServerError;
            respuesta.Message = Mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<Paciente> InternalErrorPacientes(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<Paciente>();
            respuesta.StatusCode = HttpStatusCode.InternalServerError;
            respuesta.Message = Mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }


        public static ModeloRespuesta<Doctor> InternalErrorDoctor(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<Doctor>();
            respuesta.StatusCode = HttpStatusCode.InternalServerError;
            respuesta.Message = Mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }


        public static ModeloRespuesta<string> ProcesoActualizacion_Ok(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = Mensaje;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<string> CreacionFallida_Ok(string Mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.BadRequest;
            respuesta.Message = null;
            respuesta.Objeto = Mensaje;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<Doctor> ConsultaDoctor_Ok(Doctor doctorConsultado)
        {
            var respuesta = new ModeloRespuesta<Doctor>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = doctorConsultado;
            respuesta.Data = null;
            return respuesta;
        }
        public static ModeloRespuesta<Paciente> ConsultaPaciente_Ok(Paciente pacienteConsultado)
        {
            var respuesta = new ModeloRespuesta<Paciente>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = pacienteConsultado;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<Doctor> Consulta_Doctor_NoHayDatos_NoRegistra(string mensaje)
        {
            var respuesta = new ModeloRespuesta<Doctor>();
            respuesta.StatusCode = HttpStatusCode.BadRequest;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<Paciente> Consulta_Paciente_NoHayDatos_NoRegistra(string mensaje)
        {
            var respuesta = new ModeloRespuesta<Paciente>();
            respuesta.StatusCode = HttpStatusCode.BadRequest;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<string> DatosInvalidos_Badrequest(string mensaje)
        {
            var respuesta = new ModeloRespuesta<string>();
            respuesta.StatusCode = HttpStatusCode.BadRequest;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Paciente> Paciente_Consultado_OK(View_Paciente paciente)
        {
            var respuesta = new ModeloRespuesta<View_Paciente>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = paciente;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Doctor> Doctor_Consultado_OK(View_Doctor paciente)
        {
            var respuesta = new ModeloRespuesta<View_Doctor>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = paciente;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Paciente> ConsultaPaciente_NOT_FOUND(string mensaje)
        {
            var respuesta = new ModeloRespuesta<View_Paciente>();
            respuesta.StatusCode = HttpStatusCode.NotFound;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Doctor> Consulta_Doctor_NOT_FOUND(string mensaje)
        {
            var respuesta = new ModeloRespuesta<View_Doctor>();
            respuesta.StatusCode = HttpStatusCode.NotFound;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Paciente> ConsultaPaciente_INTERNAL_ERROR(string mensaje)
        {
            var respuesta = new ModeloRespuesta<View_Paciente>();
            respuesta.StatusCode = HttpStatusCode.InternalServerError;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Doctor> Consulta_Doctor_INTERNAL_ERROR(string mensaje)
        {
            var respuesta = new ModeloRespuesta<View_Doctor>();
            respuesta.StatusCode = HttpStatusCode.InternalServerError;
            respuesta.Message = mensaje;
            respuesta.Objeto = null;
            respuesta.Data = null;
            return respuesta;
        }

        public static ModeloRespuesta<View_Paciente> Pacientes_Consultados_OK(List<View_Paciente> pacientes)
        {
            var respuesta = new ModeloRespuesta<View_Paciente>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = null;
            respuesta.Data = pacientes;
            return respuesta;
        }

        public static ModeloRespuesta<View_Doctor> Doctores_Consultados_OK(List<View_Doctor> doctores)
        {
            var respuesta = new ModeloRespuesta<View_Doctor>();
            respuesta.StatusCode = HttpStatusCode.OK;
            respuesta.Message = null;
            respuesta.Objeto = null;
            respuesta.Data = doctores;
            return respuesta;
        }
    }
}