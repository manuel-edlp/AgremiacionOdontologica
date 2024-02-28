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
    public class DomicilioService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public DomicilioService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        //public async Task<int> getIdDomicilio(string nombre)
        //{
        //    var domicilio = await _context.Domicilio
        //        .FirstOrDefaultAsync(o => o.nombre == nombre);


        //    return odontologo.id;
        //}
        public async Task<IEnumerable<DomicilioDto>> listarDomicilios()
        {
            // Realiza una consulta a la base de datos para devolver todos los odontologos
            var domicilio = await _context.Domicilio
                .Include(d => d.localidad)
                .Include(d => d.odontologo)
                .ToListAsync();

            var domiciliosDto = _mapper.Map<IEnumerable<DomicilioDto>>(domicilio);

            return domiciliosDto;
        }

        public async Task<int> altaDomicilio(DomicilioDto domicilioDto)
        {
            Odontologo odontologo = await _context.Odontologo
              .FirstOrDefaultAsync(o => o.nombre == domicilioDto.odontologo);

            if (odontologo == null)
            {
                // Si el odontologo no existe cancelo el agregar
                return 0;

            }
            Localidad localidad = await _context.Localidad
              .FirstOrDefaultAsync(l => l.nombre == domicilioDto.localidad);

            if (localidad == null)
            {
                // Si la localidad no existe cancelo el agregar
                return 0;

            }
            // Crea el domicilio y asigna el id de la localidad
            var nuevo = _mapper.Map<Domicilio>(domicilioDto);
            nuevo.idOdontologo = odontologo.id;
            nuevo.idLocalidad = localidad.id;

            _context.Domicilio.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
}
