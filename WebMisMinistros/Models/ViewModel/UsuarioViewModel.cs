using System.ComponentModel.DataAnnotations;

namespace WebMisMinistros.Models.ViewModel
{
    public class UsuarioViewModel
    {
        
        public string IdUsuario { get; set; }
      
        public string Nombre { get; set; }
    
        public string PrimerApellido { get; set; }
      
        public string SegundoApellido { get; set; }
      
        public string Correo { get; set; }
        public string Clave { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
