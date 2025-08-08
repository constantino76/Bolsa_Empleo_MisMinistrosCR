using Appi_MisMinistros.Models;

namespace Appi_MisMinistros.Repositorio.Interfaces
{
    public interface IRol
    {
        public Task<List<Rol>> getRoles();
        public Task<Rol> AgregarRol(Rol rol);
        public Task<bool> EliminarRol(int id);
    }
}
