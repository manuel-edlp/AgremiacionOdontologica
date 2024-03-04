using AgremiacionOdontologica.Controllers.Models;
using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Services
{
    public class OdontologoService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public OdontologoService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> getIdOdontologo(string nombre, string apellido)
        {
            var odontologo = await _context.Odontologo
                .FirstOrDefaultAsync(o => o.nombre == nombre && o.apellido==apellido);


            return odontologo.id;
        }
        public async Task<IEnumerable<Odontologo>> listarOdontologos()
        {
            // Realiza una consulta a la base de datos para devolver todos los odontologos
            var odontologos = await _context.Odontologo
                .Include(o => o.estado)
                .ToListAsync();



            return odontologos;
        }

        public async Task<int> altaOdontologo(OdontologoDto odontologoDto)
        {
   

            var nuevo = _mapper.Map<Odontologo>(odontologoDto);

            nuevo.idOdontologoEstado = 1;  // seteo agremiado por defecto

            _context.Odontologo.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }

        public async Task<IEnumerable<Odontologo>> BuscarOdontologo(string busqueda)
        {
            // Convertir la búsqueda a minúsculas para evitar problemas de sensibilidad a mayúsculas y minúsculas
            var busquedaMinuscula = busqueda.ToLower();

            // Filtrar los odontólogos por nombre o apellido
            var odontologos =  _context.Odontologo.Where(o => o.nombre.ToLower().Contains(busquedaMinuscula) ||
                    o.apellido.ToLower().Contains(busquedaMinuscula) ||
                    (o.nombre.ToLower() + " " + o.apellido.ToLower()).Contains(busquedaMinuscula));


            return odontologos;

        }
    }
}
