using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
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

          
          
            //var audienciaemitir = audiencias[0];
            var userClaims = new List<Claim>
        {
    new Claim("id", user.IdUsuario.ToString()),
    new Claim("name", user.Nombre),
    new Claim("email", user.Correo)
            };


   foreach (var rol in user.UsuarioRoles) {
              userClaims.Add(  new Claim("role", rol.Rol.RolNombre));
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
