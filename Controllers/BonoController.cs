using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Controllers
{
    [ApiController]
    [Route("Agremiacion/[controller]")]
    public class BonoController : ControllerBase
    {
        private readonly BonoService _bonoService;
        public BonoController(BonoService bonoService)
        {
            _bonoService = bonoService;
        }

        [HttpGet("ListarBonos")]
        public async Task<IEnumerable<BonoDto>> listarBonos()
        {
            var bonos = await _bonoService.listarBonos();

            return bonos;
        }

        [HttpPost("AltaBono")] // agrega bono
        public async Task<IActionResult> altaBono([FromBody] BonoDto bonoDto)
        {
            if (bonoDto == null)
            {
                return BadRequest("Bono vacio");
            }

            if (await _bonoService.altaBono(bonoDto))
            {
                // Devuelvo una respuesta de éxito
                return Ok();
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Bono no creado, error interno del servidor.");
            }
        }
    }
}
