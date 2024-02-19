using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Controllers
{
    [ApiController]
    [Route("Agremiacion/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;
        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("ListarPacientes")]
        public async Task<IEnumerable<PacienteDto>> listarPacientes()
        {
            var pacientes = await _pacienteService.listarPacientes();

            return pacientes;
        }

        [HttpPost("AltaPaciente")] // agrega paciente
        public async Task<IActionResult> altaPaciente([FromBody] PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
            {
                return BadRequest("paciente vacio");
            }

            if (await _pacienteService.altaPaciente(pacienteDto))
            {
                // Devuelvo una respuesta de éxito
                return Ok();
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Paciente no creado, error interno del servidor.");
            }
        }
    }
}
