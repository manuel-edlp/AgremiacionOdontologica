using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class DomicilioDto
    {
        public string calle { get; set; }
        public int numero { get; set; }
        public string localidad { get; set; }
        public string odontologo { get; set; }
    }
}
