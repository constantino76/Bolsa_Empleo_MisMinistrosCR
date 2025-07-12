using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IUsuario
    {

        public Task<bool> crearUsuario(Usuario usuario ,string  token);
        public Task<Usuario> upDateUsuario(Usuario userUpdate, string token);
        public Task<Usuario> BuscarUsuario(String correo, string clave);
    }
}
