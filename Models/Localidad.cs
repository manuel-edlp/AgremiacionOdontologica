using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgremiacionOdontologica.Controllers.Models
{
    public class Localidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public int codigoPostal { get; set; }

        [Required]
        [ForeignKey("provincia")]
        public int idProvincia { get; set; }

        public virtual Provincia provincia { get; set; }
    }
}
