using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgremiacionOdontologica.Models
{
    public class ObraSocial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public int codigo { get; set; }
    }
}