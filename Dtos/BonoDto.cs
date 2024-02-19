using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Dtos
{
    public class BonoDto
    {
        public DateTime fecha { get; set; }
        public DateTime fechaDeCarga { get; set; }
        public int numero { get; set; }
        public string bonoEstado { get; set; }
        public string odontologo { get; set; }
        public string obraSocial { get; set; }
        public string paciente { get; set; }
        public string practica { get; set; }
  
    }
}
