using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class PacienteDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int numeroAfiliado { get; set; }
        public string sexo { get; set; }
    }
}
