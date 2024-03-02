using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class OdontologoDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public int matricula { get; set; }
        public string estado { get; set; }

    }
}
