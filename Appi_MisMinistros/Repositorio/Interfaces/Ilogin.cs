using Appi_MisMinistros.Models;

namespace Appi_MisMinistros.Repositorio.Interfaces
{
    public interface Ilogin
    {
        public Task <Usuario> Login(string correo, string contrasenia);
        public int Logout();
        public Task <Usuario> BuscarUsuario(string correo);
    }
}
