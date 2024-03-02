using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Models;
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
        [HttpPut("{id}")] // modifico un videojuego completo por nombre
        public async Task<IActionResult> ModificarEntrega([FromBody] EntregaDto entregaDto, int id)
        {
            if (entregaDto == null) // verifico que los datos no esten vacios
            {
                return BadRequest("Datos de entrega inválidos");
            }

            if (await _entregaService.ModificarEntrega(entregaDto, id)) // verifico si se modifica exitosamente
            {
             
                return Ok(entregaDto);
            }
            else return NotFound("Fallo en la modificación");
        }

        [HttpDelete("{id}")] // elimina entrega
        public async Task<IActionResult> EliminarEntrega(int id)
        {
            if (await _entregaService.EliminarEntrega(id))
            {
                // Devuelvo una respuesta de éxito al eliminar
                return NoContent(); // Código 204 (Sin contenido)
            }
            else
            {
                // Si la eliminación falla o el videojuego no existe, devuelvo NotFound
                return NotFound($"Fallo al eliminar,entrega con id {id} no encontrada");
            }
        }
       
    }
}
