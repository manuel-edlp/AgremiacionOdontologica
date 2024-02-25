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
    public class ProvinciaService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public ProvinciaService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProvinciaDto>> listarProvincias()
        {
            // Realiza una consulta a la base de datos para devolver todos los odontologos
            var provincia = await _context.Localidad
                .ToListAsync();

            var provinciaDto = _mapper.Map<IEnumerable<ProvinciaDto>>(provincia);

            return provinciaDto;
        }

        public async Task<int> altaProvincia(ProvinciaDto provinciaDto)
        {
            var nuevo = _mapper.Map<Provincia>(provinciaDto);
            _context.Provincia.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
    
}

