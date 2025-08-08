using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models
{
    public class Login_
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")   ]
        public string Clave { get; set; }
    }
}
