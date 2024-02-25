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
    public class DomicilioController : ControllerBase
    {
        private readonly DomicilioService _domicilioService;
        public DomicilioController(DomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpGet("ListarDomicilios")]
        public async Task<IEnumerable<DomicilioDto>> listarDomicilios()
        {
            var domicilios = await _domicilioService.listarDomicilios();

            return domicilios;
        }

        [HttpPost("AltaOdontologo")] // agrega Domicilio
        public async Task<IActionResult> altaDomicilio([FromBody] DomicilioDto domicilioDto)
        {
            if (domicilioDto == null)
            {
                return BadRequest("Domicilio vacio");
            }
            int id = await _domicilioService.altaDomicilio(domicilioDto);
            if (id > 0)
            {
                // Devuelvo una respuesta de éxito
                return StatusCode(201, id);
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Domicilio no creado, error interno del servidor.");
            }
        }
    }
}
