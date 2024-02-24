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
    public class PacienteService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;

        public PacienteService(IConfiguration configuration, ApiDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> getIdPaciente(string nombre)
        {
            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(p => p.nombre == nombre);

            return paciente.id;
        }

        public async Task<IEnumerable<PacienteDto>> listarPacientes()
        {
            // Realiza una consulta a la base de datos para devolver todos los pacientes
            var paciente = await _context.Paciente.ToListAsync();

            var pacientesDto = _mapper.Map<IEnumerable<PacienteDto>>(paciente);

            return pacientesDto;
        }

        public async Task<bool> altaPaciente(PacienteDto pacienteDto)
        {
            var nuevo = _mapper.Map<Paciente>(pacienteDto);
            _context.Paciente.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
