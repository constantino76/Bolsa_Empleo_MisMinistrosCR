using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Repositorios.Services
{
    public class JwtokenReaderService : IJwtokenReader
    {
        public string LeerJwtoken(string token)
        { 
            var handler = new JwtSecurityTokenHandler();   // creamos una instancia de wtSecurityTokenHandler
            var tokens = handler.ReadJwtToken(token); // leemos el token 

            var Jsontoken = tokens as JwtSecurityToken;// lo casteamos a un objeto JwtSecurityToken

            // leemos los claims 
            var rol = ObtenerRol( Jsontoken);
            return rol;
        }

        public string ObtenerRol(JwtSecurityToken jsontoken) {

          
          foreach(var claim in jsontoken.Claims) { 
            
          Console.WriteLine("tipo de claim:" +claim.Type +"valor del claim" +claim.Value.ToString());  // leemos el tipo de token e imprime el contenido
            
            
            }


             var rol = jsontoken.Claims.FirstOrDefault(c => c.Type == "role");
            return rol.Value;
           
        
        }

    }
}
