using AgremiacionOdontologica.Controllers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Models
{
    public class Entrega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int inicio { get; set; }

        [Required]
        public int final { get; set; }

        [Required]
        [ForeignKey("odontologo")]
        public int idOdontologo { get; set; }
        public virtual Odontologo odontologo { get; set; }

        [Required]
        [ForeignKey("obraSocial")]
        public int idObraSocial { get; set; }
        public virtual ObraSocial obraSocial { get; set; }
    }
}
