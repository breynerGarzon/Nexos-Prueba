using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Modelo.Entidades;
using WebApi.Modelo.Modelos;
using WebApi.Negocio.Interface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IServiciosPacientes ServicioDoctores;

        public PacienteController(IServiciosPacientes servicioDoctores)
        {
            this.ServicioDoctores = servicioDoctores;
        }

        [HttpPost("AgregarPaciente")]
        public JsonResult CrearPaciente([FromBody] View_Paciente nuevoPaciente)
        {
            return new JsonResult(this.ServicioDoctores.CrearPaciente(nuevoPaciente)) { StatusCode = 200 };
        }

        [HttpPut("EditarPaciente")]
        public JsonResult EditarPaciente([FromBody] View_Paciente editarPaciente)
        {
            return new JsonResult(this.ServicioDoctores.EditarPaciente(editarPaciente)) { StatusCode = 200 };
        }

        [HttpDelete("EliminarPaciente/{IdPaciente}")]
        public JsonResult EliminarPaciente(int IdPaciente)
        {
            return new JsonResult(this.ServicioDoctores.EliminarPaciente(IdPaciente)) { StatusCode = 200 };
        }

        [HttpGet("ObtenerPaciente/{IdPaciente}")]
        public JsonResult ConsultarPacientePorId(int IdPaciente)
        {
            return new JsonResult(this.ServicioDoctores.ConsultarPacientePorId(IdPaciente)) { StatusCode = 200 };
        }
        [HttpGet("ObtenerPacientes")]
        public JsonResult ConsultarPacientes()
        {
            return new JsonResult(this.ServicioDoctores.ConsultarPacientes()) { StatusCode = 200 };
        }

        [HttpPost("ActualizarDoctor")]
        public JsonResult ConsultarPacientes([FromBody] ViewDoctorPaciente actualizacionMedico)
        {
            return new JsonResult(this.ServicioDoctores.ActualizarRelacionDoctorPaciente(actualizacionMedico)) { StatusCode = 200 };
        }

        [HttpGet("ObtenerDoctorAsignados/{IdPaciente}")]
        public JsonResult ObtenerDoctoresAsignados(int IdPaciente)
        {
            return new JsonResult(this.ServicioDoctores.ObtenerDoctoresAsignados(IdPaciente)) { StatusCode = 200 };
        }
    }
}
