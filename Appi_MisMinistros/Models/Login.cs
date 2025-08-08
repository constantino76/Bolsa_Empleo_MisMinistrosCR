using Microsoft.Build.Framework;

namespace Appi_MisMinistros.Models
{
    public class Login
    {
        [Required]
        public string Correo{ get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
