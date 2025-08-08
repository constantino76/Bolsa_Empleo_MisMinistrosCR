using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models
{
    public class Rol
    {
        [Key]
        [Required(ErrorMessage ="Debe proporcionar un Id")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        
        
        [Required (ErrorMessage ="Este campo es requerido")]
        public string RolNombre { get; set; }
        public ICollection<UsuarioRol>? UsuarioRoles { get; set; }
    }
}
