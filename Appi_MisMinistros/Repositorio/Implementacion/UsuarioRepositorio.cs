using Appi_MisMinistros.Repositorio.Interfaces;
using Appi_MisMinistros.Data;
using Appi_MisMinistros.Models;
using Appi_MisMinistros.Controllers;
using Microsoft.EntityFrameworkCore;
namespace Appi_MisMinistros.Repositorio.Implementacion
{
    public class UsuarioRepositorio:IUsuario
    {
         private readonly AppDbContext  _context;
        public UsuarioRepositorio(AppDbContext context) {
            _context = context;   
        }
        public async Task<int> InsertarUsuario(Usuario user) {
            int filasafectadas = 0;
           
            try
            {
                await _context.Tb_Usuarios.AddAsync(user);
              filasafectadas = await _context.SaveChangesAsync();
                if (filasafectadas>0) { return 200; }
               
            }

            
            catch (DbUpdateException ex) {

                Console.WriteLine("No se logro agregar el registro en la base de datos");
                
                return 2627;

            }


            catch (Exception ex)
            {
                Console.WriteLine("la ecepcion es", ex.ToString());

               
            }
            return 0;

            //if (filasafectadas == 0) return false;


        }
    }
}
