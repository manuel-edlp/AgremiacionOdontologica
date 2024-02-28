using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class EntregaDto
    {
        public int inicio { get; set; }
        public int final { get; set; }
        public string odontologo { get; set; }
        public string obraSocial { get; set; }

    }
}
