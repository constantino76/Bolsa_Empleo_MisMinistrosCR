using Appi_MisMinistros.Data;
using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Appi_MisMinistros.Repositorio.Implementacion
{
    public class LoginRepositorio : Ilogin
    {

        private readonly AppDbContext _context;

        public LoginRepositorio(AppDbContext context)
        {
            _context = context;
        }

            public async Task <Usuario >Login(string correo, string contrasenia)
        {


            if (!string.IsNullOrEmpty(correo) || !string.IsNullOrEmpty(contrasenia))
            {

                Usuario user = await BuscarUsuario(correo);
                if (user!=null) {


                    return user ;
                
                }; 
            
            
            
            }
            return null;
                
              
        }
        public int Logout()
        {
            return  0;

        }

        public async Task<Usuario> BuscarUsuario(string correo) {

            // var user_ = _context.Usuarios.Include(e => e.UsuarioRoles).ThenInclude(ur => ur.Rol).FirstOrDefault(u => u.Correo == email && u.Clave == clave);


            Usuario user = _context.Tb_Usuarios.Include(e => e.UsuarioRoles).ThenInclude(ur => ur.Rol).FirstOrDefault(c => c.Correo == correo);

            if (user != null) return   user;

            return null;
        
        }

       
    }
}
