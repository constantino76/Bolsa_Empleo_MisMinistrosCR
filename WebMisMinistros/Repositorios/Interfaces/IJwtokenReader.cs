using System.IdentityModel.Tokens.Jwt;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface IJwtokenReader
    {
        public string LeerJwtoken(string token);

        public string ObtenerRol(JwtSecurityToken jsontoken);


    }
}
