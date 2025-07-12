using Appi_MisMinistros.Models;

namespace Appi_MisMinistros.Repositorio.Interfaces
{
    public interface IUsuario
    {
        public Task<bool> InsertarUsuario(Usuario usuario);
    }
}
