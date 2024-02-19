using AgremiacionOdontologica.Data;
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

        public ObraSocialService(IConfiguration configuration, ApiDb context)
        {
            _context = context;

        }

        public async Task<int> getIdObraSocial(string nombre)
        {
            var obraSocial = await _context.ObraSocial
                .FirstOrDefaultAsync(o => o.nombre == nombre);

            return obraSocial.id;
        }
    }
}
  
