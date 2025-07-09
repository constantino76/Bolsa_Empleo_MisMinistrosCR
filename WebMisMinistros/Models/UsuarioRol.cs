namespace WebMisMinistros.Models
{
    public class UsuarioRol
    {
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }

    }
}
