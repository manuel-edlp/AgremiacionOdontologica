using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AgremiacionOdontologica.Services
{
    public class BonoService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;
        private readonly OdontologoService _odontologoService;
        private readonly ObraSocialService _obraSocialService;
        private readonly PacienteService _pacienteService;
        private readonly PracticaService _practicaService;

        public BonoService(IConfiguration configuration, ApiDb context, IMapper mapper, ObraSocialService obraSocialService, OdontologoService odontologoService, PacienteService pacienteService, PracticaService practicaService)
        {
            _context = context;
            _mapper = mapper;
            _obraSocialService = obraSocialService;
            _odontologoService = odontologoService;
            _pacienteService = pacienteService;
            _practicaService = practicaService;

        }
        public async Task<IEnumerable<BonoDto>> listarBonos()
        {
            // Realiza una consulta a la base de datos para devolver todos los bonos
            var bonos = await _context.Bono
                .Include(b => b.estado)
                .Include(b => b.odontologo)
                .Include(b => b.obraSocial)
                .Include(b => b.paciente)
                .Include(b => b.practica)
                .ToListAsync();

            var bonosDto = _mapper.Map<IEnumerable<BonoDto>>(bonos);


            return bonosDto;
        }
        
        public async Task<bool> altaBono(BonoDto bonoDto)
        {
            var nuevo = new Bono();
            nuevo.fecha = bonoDto.fecha;
            nuevo.fechaDeCarga = DateTime.Now;
            nuevo.numero = bonoDto.numero;

            nuevo.idBonoEstado = 2; // seteo estado "Ingresado"   (Estados: 1. Entregado  2. Ingresado)

            nuevo.idOdontologo = await _odontologoService.getIdOdontologo(bonoDto.odontologo);
            nuevo.idObraSocial = await _obraSocialService.getIdObraSocial(bonoDto.obraSocial);
            nuevo.idPaciente = await _pacienteService.getIdPaciente(bonoDto.paciente);
            nuevo.idPractica = await _practicaService.getIdPractica(bonoDto.practica);


            _context.Bono.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
