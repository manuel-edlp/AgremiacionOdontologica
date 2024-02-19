using AgremiacionOdontologica.Data;
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

        public PracticaService(IConfiguration configuration, ApiDb context)
        {
            _context = context;

        }
        public async Task<int> getIdPractica(string nombre)
        {
            var practica = await _context.Practica
                .FirstOrDefaultAsync(p => p.nombre == nombre);

            return practica.id;
        }
    }
    
}
