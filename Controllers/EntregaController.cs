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
    public class EntregaController : ControllerBase
    {
        private readonly EntregaService _entregaService;
        public EntregaController(EntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        [HttpGet("Listar")]
        public async Task<IEnumerable<EntregaDto>> listarEntregas()
        {
            var entrega = await _entregaService.listarEntregas();

            return entrega;
        }

        [HttpPost("AltaEntrega")] // agrega bono
        public async Task<IActionResult> altaEntrega([FromBody] EntregaDto entregaDto)
        {
            if (entregaDto == null)
            {
                return BadRequest("Entrega vacio");
            }

            if (await _entregaService.altaEntrega(entregaDto))
            {
                // Devuelvo una respuesta de éxito
                return Ok();
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Entrega no creada, error interno del servidor.");
            }
        }
    }
}
