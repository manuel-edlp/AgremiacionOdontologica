using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Controllers.Models
{
    public class Odontologo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]
        public int matricula { get; set; }

        [Required]
        public int dni { get; set; }

        [Required]
        [ForeignKey("estado")]
        public int idOdontologoEstado { get; set; }

        public virtual OdontologoEstado estado { get; set; }
    }
}
