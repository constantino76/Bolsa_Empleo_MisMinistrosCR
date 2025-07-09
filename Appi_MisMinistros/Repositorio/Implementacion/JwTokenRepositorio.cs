using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appi_MisMinistros.Repositorio.Implementacion
{
    public class JwTokenRepositorio : IjwToken
    {
        private readonly IConfiguration _config;
        public JwTokenRepositorio(IConfiguration config) {

            _config = config;
        
        
        }
        public async Task<string> GenerarToken(Usuario user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var userClaims = new List<Claim>
        {
    new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
    new Claim(ClaimTypes.Name, user.Nombre),
    new Claim(ClaimTypes.Email, user.Correo)
            };


   foreach (var rol in user.UsuarioRoles) {
                new Claim(ClaimTypes.Role, rol.Rol.RolNombre);
            }


            var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Audience"],
                        claims: userClaims,
                        expires: DateTime.Now.AddDays(5),
                        signingCredentials: credentials
                        );

            return  new JwtSecurityTokenHandler().WriteToken(token);



        }

           

          
        
    }
}
