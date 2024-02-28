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
    public class ObraSocialService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public ObraSocialService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ObraSocialDto>> listarObrasSociales()
        {
            // Realiza una consulta a la base de datos para devolver todos los pacientes
            var obraSocial = await _context.ObraSocial.ToListAsync();

            var obrasSocialesDto = _mapper.Map<IEnumerable<ObraSocialDto>>(obraSocial);

            return obrasSocialesDto;
        }
        public async Task<int> getIdObraSocial(string nombre)
        {
            var obraSocial = await _context.ObraSocial
                .FirstOrDefaultAsync(o => o.nombre == nombre);

            return obraSocial.id;
        }

        public async Task<bool> altaObraSocial(ObraSocialDto obraSocialDto)
        {
            var nuevo = _mapper.Map<ObraSocial>(obraSocialDto);
            _context.ObraSocial.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
  
