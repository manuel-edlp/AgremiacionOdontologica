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
    public class LocalidadController : ControllerBase
    {
        private readonly LocalidadService _localidadService;
        public LocalidadController(LocalidadService localidadService)
        {
            _localidadService = localidadService;
        }

        [HttpGet("ListarLocalidades")]
        public async Task<IEnumerable<LocalidadDto>> listarLocalidades()
        {
            var domicilios = await _localidadService.listarLocalidades();

            return domicilios;
        }

        [HttpPost("AltaLocalidad")] // agrega Localidad
        public async Task<IActionResult> altaLocalidad([FromBody] LocalidadDto localidadDto)
        {
            if (localidadDto == null)
            {
                return BadRequest("Localidad vacio");
            }
            int id = await _localidadService.altaLocalidad(localidadDto);
            if (id > 0)
            {
                // Devuelvo una respuesta de éxito
                return StatusCode(201, id);
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Localidad no creado, error interno del servidor.");
            }
        }
    }
}
