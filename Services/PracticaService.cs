using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Services
{
    public class PracticaService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public PracticaService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<PracticaDto>> listarPracticas()
        {
            // Realiza una consulta a la base de datos para devolver todos los bonos
            var practicas = await _context.Practica.ToListAsync();

            var practicasDto = _mapper.Map<IEnumerable<PracticaDto>>(practicas);

            return practicasDto;
        }

        public async Task<int> getIdPractica(string nombre)
        {
            var practica = await _context.Practica
                .FirstOrDefaultAsync(p => p.nombre == nombre);

            return practica.id;
        }

        public async Task<bool> altaPractica(PracticaDto practicaDto)
        {
            var nuevo = _mapper.Map<Practica>(practicaDto);

            _context.Practica.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
    
}
