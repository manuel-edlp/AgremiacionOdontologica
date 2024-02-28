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
    public class EntregaService
    {
        private readonly ApiDb _context;
        private readonly IMapper _mapper;
        private readonly OdontologoService _odontologoService;
        private readonly ObraSocialService _obraSocialService;


        public EntregaService(IConfiguration configuration, ApiDb context, IMapper mapper, ObraSocialService obraSocialService, OdontologoService odontologoService)
        {
            _context = context;
            _mapper = mapper;
            _obraSocialService = obraSocialService;
            _odontologoService = odontologoService;


        }
        public async Task<IEnumerable<EntregaDto>> listarEntregas()
        {
            // Realiza una consulta a la base de datos para devolver todos los bonos
            var entregas = await _context.Entrega
                .Include(b => b.odontologo)
                .Include(b => b.obraSocial)
                .ToListAsync();

            var entregasDto = _mapper.Map<IEnumerable<EntregaDto>>(entregas);


            return entregasDto;
        }

        public async Task<bool> altaEntrega(EntregaDto entregaDto)
        {
            var nuevo = new Entrega();
            nuevo.inicio = entregaDto.inicio;
            nuevo.final = entregaDto.final;

            nuevo.idOdontologo = await _odontologoService.getIdOdontologo(entregaDto.odontologo);
            nuevo.idObraSocial = await _obraSocialService.getIdObraSocial(entregaDto.obraSocial);


            _context.Entrega.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
