using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Diagnostics;
using WebMisMinistros.Models;
using WebMisMinistros.Models.ViewModel;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuario _iusuario;
        private readonly IRol _rolservice;
        public UsuariosController(ILogger<UsuariosController> logger, IUsuario iusuario,IRol rolservice)
        {
            _logger = logger;
            _iusuario = iusuario;
            _rolservice = rolservice;
        }

        public IActionResult Index()
        {

            return View();

        }
        
        public async Task<IActionResult> CrearUsuario()
        {

            UsuarioViewModel user = new UsuarioViewModel()
            {

                Roles = await _rolservice.getRoles()// llamada del metodo del servicio para  obtener los roles

            };
            //user.Roles=GetRoles();
            return View(user);

        }
       

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(UsuarioViewModel usuarioviewmodel,int idRol)
        {

            string token = HttpContext.Session.GetString("jwtk");

            if (usuarioviewmodel == null)
            {


                return RedirectToAction("index","Usuarios");


            }


            try
            {
                Usuario usuario = new Usuario()
                {

                    IdUsuario = usuarioviewmodel.IdUsuario,
                    Nombre = usuarioviewmodel.Nombre,
                    PrimerApellido = usuarioviewmodel.PrimerApellido,
                    SegundoApellido = usuarioviewmodel.SegundoApellido,
                    Correo = usuarioviewmodel.Correo,
                    Clave = usuarioviewmodel.Clave,
                    CambiarClave=true

                };



        var respuesta =await _iusuario.crearUsuario(usuario, token);

                HttpContext.Session.SetString("Mensaje",respuesta.Mensaje);
                HttpContext.Session.SetString("CodigoRespuesta", Convert.ToString(respuesta.CodigoRespuesta));
                switch (respuesta.CodigoRespuesta) {

                    case 200:
                        HttpContext.Session.SetString("class-boostrap", "bg-success");
                break;
                    case 400:
                        HttpContext.Session.SetString("class-boostrap", "bg-danger");
                        break;

                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("Ha ocurrido un error tipo :", ex.ToString());
            }
            return RedirectToAction("CrearUsuario");

        }


        public async Task<ActionResult> CrearNuevaCuenta()
        {



            return View();

        }

        [HttpPost]

        public async Task<ActionResult> CrearNuevaCuenta(UsuarioViewModel usuarioviewmodel)
        { 


            Usuario user = new Usuario()
            {
                IdUsuario = usuarioviewmodel.IdUsuario,
                Nombre = usuarioviewmodel.Nombre,
                PrimerApellido = usuarioviewmodel.PrimerApellido,
                SegundoApellido = usuarioviewmodel.SegundoApellido,
                Correo = usuarioviewmodel.Correo,
                Clave = usuarioviewmodel.Clave,

            };
        var respuesta= await _iusuario.CrearNuevoUsuario(user);


            switch (respuesta.CodigoRespuesta)
            {

                case 200:
                    HttpContext.Session.SetString("class-boostrap", "bg-success");
                    break;
                case 400:
                    HttpContext.Session.SetString("class-boostrap", "alert alert-danger");
                    break;

            }

            HttpContext.Session.SetString("Mensaje", respuesta.Mensaje);
            HttpContext.Session.SetString("CodigoRespuesta", Convert.ToString(respuesta.CodigoRespuesta));

            return RedirectToAction("CrearNuevaCuenta");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
