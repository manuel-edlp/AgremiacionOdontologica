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
    public class OdonotologoController : ControllerBase
    {
        private readonly OdontologoService _odontologoService;
        public OdonotologoController(OdontologoService odontologoService)
        {
            _odontologoService = odontologoService;
        }

        [HttpGet("ListarOdontologos")]
        public async Task<IEnumerable<OdontologoDto>> listarPacientes()
        {
            var odontologos = await _odontologoService.listarOdontologos();

            return odontologos;
        }

        [HttpPost("AltaOdontologo")] // agrega Odontologo
        public async Task<IActionResult> altaOdontologo([FromBody] OdontologoDto odontologoDto)
        {
            if (odontologoDto == null)
            {
                return BadRequest("Odontologo vacio");
            }

            if (await _odontologoService.altaOdontologo(odontologoDto))
            {
                // Devuelvo una respuesta de éxito
                return Ok();
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Odontologo no creado, error interno del servidor.");
            }
        }
    }
}
