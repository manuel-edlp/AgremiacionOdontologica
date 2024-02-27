using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Controllers.Models
{
    public class Domicilio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string calle { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        [ForeignKey("localidad")]
        public int idLocalidad { get; set; }

        public virtual Localidad localidad { get; set; }

        [Required]
        [ForeignKey("odontologo")]
        public int idOdontologo { get; set; }

        public virtual Odontologo odontologo { get; set; }
    }
}
