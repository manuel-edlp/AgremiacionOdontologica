using AgremiacionOdontologica.Controllers.Models;
using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

        public async Task<int> getIdOdontologo(string nombre)
        {
            var odontologo = await _context.Odontologo
                .FirstOrDefaultAsync(o => o.nombre == nombre);


            return odontologo.id;
        }
        public async Task<IEnumerable<OdontologoDto>> listarOdontologos()
        {
            // Realiza una consulta a la base de datos para devolver todos los odontologos
            var odontologo = await _context.Odontologo
                .Include(o => o.estado)
                .ToListAsync();

            var odontologosDto = _mapper.Map<IEnumerable<OdontologoDto>>(odontologo);

            return odontologosDto;
        }

        public async Task<int> altaOdontologo(OdontologoDto odontologoDto)
        {
            var nuevo = _mapper.Map<Odontologo>(odontologoDto);
            _context.Odontologo.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo.id;
        }
    }
}
