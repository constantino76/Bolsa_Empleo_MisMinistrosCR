using Appi_MisMinistros.Data;
using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Appi_MisMinistros.Repositorio.Implementacion
{
    public class RolRepositorio : IRol
    {
        private readonly AppDbContext _context;
        public RolRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> AgregarRol(Rol rol)
        {
            //verificamos si el rol existe
            var rolExiste = await _context.Tb_Roles.FirstOrDefaultAsync(e => e.IdRol == rol.IdRol);

            //validar si es null el rolExiste
            if (rolExiste==null) {

                return null;// este null lo interpretaremos como que el rol existe 
            }
            try {


                // recordar usar await en todo lo que es asincronico en metodos 
                await _context.Tb_Roles.AddAsync(rol);
                await _context.SaveChangesAsync();
            }


            catch (Exception ex) {

                Console.WriteLine("Ocurrio un error de tipo: =>", ex.ToString());
            
            }
           
            return rol;
        }

        public async Task<bool> EliminarRol(int id)
        {
            var RolDelete = await _context.Tb_Roles. FirstOrDefaultAsync(r => r.IdRol == id);
            if (RolDelete==null) { return false; }


            try {
              _context.Tb_Roles.Remove(RolDelete);
                await _context.SaveChangesAsync();
                return true;
            }


            catch (Exception ex ) {

                Console.WriteLine("Ocurrio un error", ex.ToString);
            
            }


            return false;
        }

        public async  Task<List<Rol>> getRoles()
        {
            var listroles = await _context.Tb_Roles.ToListAsync();
            return listroles;
     
        }
    }
}
