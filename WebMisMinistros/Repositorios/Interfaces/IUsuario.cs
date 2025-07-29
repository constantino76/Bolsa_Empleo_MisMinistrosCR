using WebMisMinistros.MensajesHttp;
using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IUsuario
    {

        public Task<Respuesta> crearUsuario(Usuario usuario, string token);
        public Task<Respuesta> CrearNuevoUsuario(Usuario usuario);
        public Task<Usuario> upDateUsuario(Usuario userUpdate, string token);
        public Task<Usuario> BuscarUsuario(String correo, string clave);
    }
}
