using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models.ViewModel
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Numero de cedula requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$")]
        [Display(Name = "ID")]
        public string IdUsuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Campo obligatorio")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Clave { get; set; }
        public bool CambiarClave { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
