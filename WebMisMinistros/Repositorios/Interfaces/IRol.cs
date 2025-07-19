using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IRol
    {


        public Task<List<Rol>> getRoles();  
    }
}
