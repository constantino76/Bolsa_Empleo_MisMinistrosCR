using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appi_MisMinistros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        // GET: AccesoController


        private readonly Ilogin _ilogin;
        private readonly IjwToken _jwtoken; 
        public AccesoController(Ilogin ilogin,IjwToken ijwToken)
        {
            _ilogin = ilogin;
            _jwtoken = ijwToken;
        }


        [AllowAnonymous]
        [HttpPost("auth/login")]
        public async Task<ActionResult> Login([FromBody] Login userlogin)
        {
            if (!ModelState.IsValid) {



                return BadRequest(ModelState);
            }
            
            var token = "";
            string correo = userlogin.Correo;
            string clave = userlogin.Clave;

            Usuario usuario = await _ilogin.Login(correo, clave);
            //codigo para que no pueda ser accedido desde javascript el token
            if (usuario != null)
            {

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Importante en producción con HTTPS
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddHours(1)
                };
                  token = await _jwtoken.GenerarToken(usuario);

                Response.Cookies.Append("JwtToken", token, cookieOptions);
                //aca devolvemos el token 

            }
            string rol_ = "";
            foreach (var rol in usuario.UsuarioRoles)
            {

                rol_ = rol.Rol.RolNombre;
            }
            return Ok(new
            {
                token,
                user = new
                {
                    usuario.IdUsuario,
                    usuario.Nombre,
                    rol_
                }
            });

        }

            // GET: AccesoController/Details/5
        //    public ActionResult Logout(int id)
        //{
        //    return Ok();
        //}

        

        // POST: AccesoController/Create
        

       

       
    }
}
