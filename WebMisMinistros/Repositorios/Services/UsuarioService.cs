using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Repositorios.implementacion
{
    public class UsuarioService : IUsuario
    {
       
        public async  Task<bool> crearUsuario(Usuario usuario)
        {
            if (usuario == null) return false;
           
            return true;
        }
        public Task<Usuario> BuscarUsuario(string correo, string clave)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> upDateUsuario(Usuario userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
