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

            nuevo.idOdontologo = await _odontologoService.getIdOdontologo(entregaDto.odontologoNombre, entregaDto.odontologoApellido);
            nuevo.idObraSocial = await _obraSocialService.getIdObraSocial(entregaDto.obraSocial);


            _context.Entrega.Add(nuevo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Entrega>getEntregaById(int id)
        {
            // Realiza una consulta a la base de datos para devolver todos los bonos
            var entrega = await _context.Entrega.Where(e => e.id == id)
                .Include(b => b.odontologo)
                .Include(b => b.obraSocial)
                .FirstOrDefaultAsync();

            return entrega;
        }

        public async Task<bool> ModificarEntrega(EntregaDto entregaDto , int id)
        {
            try
            {
                var entrega = await _context.Entrega
                    .Include(e => e.odontologo)
                    .Include(e => e.obraSocial)
                    .FirstOrDefaultAsync(e => e.id == id);

                if (entrega == null) // verifico que se encuentre 
                {
                    return false;
                }

                var odontologo = await _context.Odontologo
                    .Where(o => o.nombre == entregaDto.odontologoNombre && o.apellido== entregaDto.odontologoApellido)
                    .FirstOrDefaultAsync();

                if (odontologo == null)
                {
                    return false;
                } 
                
                var obraSocial = await _context.ObraSocial
                    .Where(o => o.nombre == entregaDto.obraSocial)
                    .FirstOrDefaultAsync();

                if (obraSocial == null)
                {
                    return false;
                }

                entrega.inicio = entregaDto.inicio;
                entrega.final = entregaDto.final;
                entrega.idOdontologo = odontologo.id;
                entrega.idObraSocial = obraSocial.id;

                await _context.SaveChangesAsync();  // actualizo bd

                return true;    // retorno modificacion exitosa

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> EliminarEntrega(int id)
        {
            try
            {
                // Obtener el entrega del contexto de la base de datos
                Entrega entrega = await _context.Entrega
                 .FirstOrDefaultAsync(e => e.id == id);

                // Si el entrega no existe, devuelve falso
                if (entrega == null)
                {
                    return false;
                }

                // Elimino el videojuego del contexto de la base de datos
                _context.Entrega.Remove(entrega);

                // Guardo los cambios en la base de datos
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
