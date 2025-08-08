using WebMisMinistros.MensajesHttp;
using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IRol
    {
        public Task<Respuesta> InsertarRol(Rol rol,string token);

        public Task<List<Rol>> getRoles();  
    }
}
