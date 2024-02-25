using AgremiacionOdontologica.Controllers.Models;
using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
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
                .ToListAsync();

            var domiciliosDto = _mapper.Map<IEnumerable<DomicilioDto>>(domicilio);

            return domiciliosDto;
        }

        public async Task<int> altaDomicilio(DomicilioDto domicilioDto)
        {
            var nuevo = _mapper.Map<Domicilio>(domicilioDto);
            _context.Domicilio.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
}
