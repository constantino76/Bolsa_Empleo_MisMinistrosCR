namespace Appi_MisMinistros.Models
{
    public class UsuarioRol
    {
       public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }//propiedad de  navegacion

        public int RolId { get; set; }
        public Rol Rol { get; set; } //propiedad de navegacion

    }
}