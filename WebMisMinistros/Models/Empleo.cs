using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models
{
    public class Empleo
    { public int ID { get; set; }
        [Required]
        public string NombreEmpleo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio {  get; set; }
    }
}
