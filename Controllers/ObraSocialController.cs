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
    public class ObraSocialController : ControllerBase
    {
        private readonly ObraSocialService _obraSocialService;
        public ObraSocialController(ObraSocialService obraSocialService)
        {
            _obraSocialService = obraSocialService;
        }

        [HttpGet("ListarObrasSociales")]
        public async Task<IEnumerable<ObraSocial>> listarObrasSociales()
        {
            var obrasSociales = await _obraSocialService.listarObrasSociales();

            return obrasSociales;
        }

        [HttpPost("AltaObraSocial")] // agrega obrasSociales
        public async Task<IActionResult> altaObraSocial([FromBody] ObraSocialDto obraSocialDto)
        {
            if (obraSocialDto == null)
            {
                return BadRequest("Obra social vacia");
            }
          
            if (await _obraSocialService.altaObraSocial(obraSocialDto))
            {
                // Devuelvo una respuesta de éxito
                return StatusCode(201,"Obra Social cargada con exito");
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Obra Social no creada, error interno del servidor.");
            }
        }
        [HttpGet("getIdObraSocial/{nombre}")] // agrega obrasSociales
        public async Task<IActionResult> getIdObraSocial(string nombre)
        {
            if (nombre == null)
            {
                return BadRequest("Obra social vacia");
            }
            var id = await _obraSocialService.getIdObraSocial(nombre);
            if (id != null)
            {
                // Devuelvo una respuesta de éxito
                return StatusCode(201, id);
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "id nulo");
            }

        }
    }
}
