using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Numero de cedula requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$")]
        public string IdUsuario { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Primer apellidorequerido")]
       
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "segundo apellido requerido")]
        public string SegundoApellido { get; set; }
        [Required (ErrorMessage ="Campo obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Clave { get; set; }
        public bool CambiarClave { get; set; }
        public ICollection<UsuarioRol>? UsuarioRoles { get; set; }

    }
}
