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
    public class PracticaController : ControllerBase
    {
        private readonly PracticaService _practicaService;
        public PracticaController(PracticaService practicaService)
        {
            _practicaService = practicaService;
        }

        [HttpGet("ListarPracticas")]
        public async Task<IEnumerable<PracticaDto>> listarPracticas()
        {
            var practicas = await _practicaService.listarPracticas();

            return practicas;
        }

        [HttpPost("AltaPractica")] // agrega practica
        public async Task<IActionResult> altaBono([FromBody] PracticaDto practicaDto)
        {
            if (practicaDto == null)
            {
                return BadRequest("practica vacia");
            }

            if (await _practicaService.altaPractica(practicaDto))
            {
                // Devuelvo una respuesta de éxito
                return Ok();
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Practica no creada, error interno del servidor.");
            }
        }
    }
}
