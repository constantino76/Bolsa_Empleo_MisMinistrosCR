using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [Display(Name ="Rol")]
        
        [Required]
        public string RolNombre { get; set; }
        public ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
