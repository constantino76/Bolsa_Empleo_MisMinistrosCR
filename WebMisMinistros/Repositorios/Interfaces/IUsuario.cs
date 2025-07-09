using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IUsuario
    {

        public Task<bool> crearUsuario(Usuario usuario);
        public Task<Usuario> upDateUsuario(Usuario userUpdate);
        public Task<Usuario> BuscarUsuario(String correo, string clave);
    }
}
