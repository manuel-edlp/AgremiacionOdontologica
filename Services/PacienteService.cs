using AgremiacionOdontologica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Services
{
    public class PacienteService
    {
        private readonly ApiDb _context;

        public PacienteService(IConfiguration configuration, ApiDb context)
        {
            _context = context;

        }

        public async Task<int> getIdPaciente(string nombre)
        {
            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(p => p.nombre == nombre);

            return paciente.id;
        }
    }
}
