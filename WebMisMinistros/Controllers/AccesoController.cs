using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuario _iusuario;

        private readonly ILogin _ilogin;
        private readonly IJwtokenReader _jwtokenReader;
        // GET: AccesoController
        public AccesoController(IUsuario iusuario, ILogin ilogin, IJwtokenReader jwtokenReader)
        {

            _iusuario = iusuario;

            _ilogin = ilogin;
            _jwtokenReader = jwtokenReader;


        }

        public ActionResult Login()
        {
            return  View();

        }

        // GET: AccesoController/Details/5
        [HttpPost]
        public async Task<ActionResult> Login(Login_ user)
        {
          

            if (String.IsNullOrEmpty(user.Correo) || String.IsNullOrEmpty(user.Clave))
            {


                return RedirectToAction("Login");

            }

            try
            {
                // recibe el objeto token
                var jwtk = await _ilogin.Login(user);
                if (jwtk != null)
                    HttpContext.Session.SetString("jwtk", jwtk.token);
                var jwtkdata = HttpContext.Session.GetString("jwtk");

                if (jwtkdata != null)
                {
                    string rol = _jwtokenReader.LeerJwtoken(jwtkdata);

                    HttpContext.Session.SetString("rol", rol);
                    HttpContext.Session.SetString("email",user.Correo);// hacems esto asumiendo que la funcion Login fue exitosa, 
                }



            }

            catch
            {


            }


            return RedirectToAction("Dasboard", "Home");
        }




        // funcionalidad para cerrar sesion 
        public IActionResult Logout()
        {


            HttpContext.Session.Remove("jwtk");
            HttpContext.Session.Remove("rol");
            return RedirectToAction("Login", "Acceso");

        }



    }
}
