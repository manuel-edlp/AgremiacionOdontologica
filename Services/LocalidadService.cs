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
            // Verifico si la provincia ya existe en la base de datos
            Provincia provincia = await _context.Provincia
                .FirstOrDefaultAsync(p => p.nombre == localidadDto.provincia);

            if (provincia == null)
            {
                // Si el provincia no existe cancelo el agregar
                return 0;

            }

            // Crea la localidad y asigna el id de la provincia
            var nuevo = _mapper.Map<Localidad>(localidadDto);
            nuevo.idProvincia = provincia.id;
            
            _context.Localidad.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
}
