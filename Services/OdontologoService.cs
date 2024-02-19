using AgremiacionOdontologica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Services
{
    public class OdontologoService
    {
        private readonly ApiDb _context;

        public OdontologoService(IConfiguration configuration, ApiDb context)
        {
            _context = context;

        }

        public async Task<int> getIdOdontologo(string nombre)
        {
            var odontologo = await _context.Odontologo
                .FirstOrDefaultAsync(o => o.nombre == nombre);


            return odontologo.id;
        }
    }
}
