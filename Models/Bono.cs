using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AgremiacionOdontologica.Controllers.Models;
using AgremiacionOdontologica.Models;

namespace AgremiacionOdontologica.Models
{
    public class Bono
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        [ForeignKey("estado")]
        public int idBonoEstado { get; set; }
        public virtual BonoEstado estado { get; set; }

        [Required]
        [ForeignKey("odontologo")]
        public int idOdontologo { get; set; }
        public virtual Odontologo odontologo { get; set; }

        [Required]
        [ForeignKey("obraSocial")]
        public int idObraSocial { get; set; }
        public virtual ObraSocial obraSocial { get; set; }

        [Required]
        [ForeignKey("paciente")]
        public int idPaciente { get; set; }
        public virtual Paciente paciente { get; set; }

        [Required]
        [ForeignKey("practica")]
        public int idPractica { get; set; }
        public virtual Practica practica { get; set; }
    }
}
