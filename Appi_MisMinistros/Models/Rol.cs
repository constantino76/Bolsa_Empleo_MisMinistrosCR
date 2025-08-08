using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Appi_MisMinistros.Models
{
    public class Rol
    {
        [Required]
        public int IdRol { get; set; }


        [Required]
        public string RolNombre { get; set; }
        public ICollection<UsuarioRol>? UsuarioRoles { get; set; }
    }
}
