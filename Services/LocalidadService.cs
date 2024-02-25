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
    public class LocalidadService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public LocalidadService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<LocalidadDto>> listarLocalidades()
        {
            // Realiza una consulta a la base de datos para devolver todos los odontologos
            var localidad = await _context.Localidad
                .Include(l => l.provincia)
                .ToListAsync();

            var domiciliosDto = _mapper.Map<IEnumerable<LocalidadDto>>(localidad);

            return domiciliosDto;
        }

        public async Task<int> altaLocalidad(LocalidadDto localidadDto)
        {
            var nuevo = _mapper.Map<Localidad>(localidadDto);
            _context.Localidad.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
}
