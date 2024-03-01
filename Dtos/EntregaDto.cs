using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class EntregaDto
    {
        public int id{ get; set; }
        public int inicio { get; set; }
        public int final { get; set; }
        public string odontologoNombre { get; set; }
        public string odontologoApellido { get; set; }
        public string obraSocial { get; set; }

    }
}
