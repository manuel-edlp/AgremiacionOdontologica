using AgremiacionOdontologica.Controllers.Models;
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
    public class OdontologoController : ControllerBase
    {
        private readonly OdontologoService _odontologoService;
        public OdontologoController(OdontologoService odontologoService)
        {
            _odontologoService = odontologoService;
        }

        [HttpGet("ListarOdontologos")]
        public async Task<IEnumerable<Odontologo>> listarOdontologos()
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
            int id = await _odontologoService.altaOdontologo(odontologoDto);
            if (id > 0)
            {
                // Devuelvo una respuesta de éxito
                return StatusCode(201,id);
            }
            else
            {
                // Retorno respuesta de fallo del servidor con el codigo 500
                return StatusCode(500, "Odontologo no creado, error interno del servidor.");
            }
        }
        [HttpGet("listar/{busqueda}")] // Listar odontologos buscando por nombre y/o apellido
        public async Task<IEnumerable<Odontologo>> BuscarOdontologo(string busqueda) => await _odontologoService.BuscarOdontologo(busqueda);
   
    }
}
