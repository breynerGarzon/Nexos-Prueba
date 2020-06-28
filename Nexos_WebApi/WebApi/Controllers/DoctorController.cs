using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Modelo.Modelos;
using WebApi.Negocio.Interface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiciosDoctores ServicioDoctores;

        public DoctorController(ILogger<WeatherForecastController> logger, IServiciosDoctores servicioDoctores)
        {
            this.ServicioDoctores = servicioDoctores;
            _logger = logger;
        }

        [HttpPost("AgregarDoctor")]
        public JsonResult CrearPaciente([FromBody] View_Doctor nuevoPaciente)
        {
            return new JsonResult(this.ServicioDoctores.CrearDoctor(nuevoPaciente)) { StatusCode = 200 };
        }

        [HttpPut("EditarDoctor")]
        public JsonResult EditarPaciente([FromBody] View_Doctor editarPaciente)
        {
            return new JsonResult(this.ServicioDoctores.EditarDoctor(editarPaciente)) { StatusCode = 200 };
        }

        [HttpDelete("EliminarDoctor/{IdDoctor}")]
        public JsonResult EliminarPaciente(int IdDoctor)
        {
            return new JsonResult(this.ServicioDoctores.EliminarDoctor(IdDoctor)) { StatusCode = 200 };
        }

        [HttpGet("ObtenerDoctor/{IdDoctor}")]
        public JsonResult ConsultarPacientePorId(int IdDoctor)
        {
            return new JsonResult(this.ServicioDoctores.ConsultarDoctorPorId(IdDoctor)) { StatusCode = 200 };
        }
        [HttpGet("ObtenerDoctores")]
        public JsonResult ConsultarPacientes()
        {
            return new JsonResult(this.ServicioDoctores.ConsultarDoctores()) { StatusCode = 200 };
        }
    }
}
