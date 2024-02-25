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
    public class ProvinciaController : ControllerBase
    {
        private readonly ProvinciaService _provinciaService;
        public ProvinciaController(ProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        [HttpGet("ListarProvincias")]
        public async Task<IEnumerable<ProvinciaDto>> listarProvincias()
        {
            var provincias = await _provinciaService.listarProvincias();

            return provincias;
        }

        [HttpPost("AltaProvincia")] // agrega Provincia
        public async Task<IActionResult> altaProvincia([FromBody] ProvinciaDto provinciaDto)
        {
            if (provinciaDto == null)
            {
                return BadRequest("Localidad vacio");
            }
            int id = await _provinciaService.altaProvincia(provinciaDto);
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
