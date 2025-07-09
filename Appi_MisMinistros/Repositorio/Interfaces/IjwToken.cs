using Appi_MisMinistros.Models;

namespace Appi_MisMinistros.Repositorio.Interfaces
{
    public interface IjwToken
    {

        public Task <string> GenerarToken(Usuario usuario);
    }
}
