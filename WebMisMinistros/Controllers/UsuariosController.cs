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
        public UsuariosController(ILogger<UsuariosController> logger, IUsuario iusuario)
        {
            _logger = logger;
            _iusuario = iusuario;
        }

        public IActionResult Index()
        {

            return View();

        }
        public async Task<IActionResult> CrearUsuario()
        {

            UsuarioViewModel user = new UsuarioViewModel()
            {

                Roles = GetRoles()

            };
            //user.Roles=GetRoles();
            return View(user);

        }
        public List<Rol> GetRoles()
        {

            List<Rol> roles = new List<Rol>();

            roles.Add(new Rol() { IdRol = 1, RolNombre = "Administrador" });

            roles.Add(new Rol() { IdRol = 2, RolNombre = "Developer" });
            return roles;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioViewModel usuarioviewmodel, int IdRol)
        {

            string token = HttpContext.Session.GetString("jwtk");

            if (usuarioviewmodel == null)
            {


                return RedirectToAction("index");


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
                    Clave = usuarioviewmodel.Clave

                };



        var respuesta =await _iusuario.crearUsuario(usuario, token);

                HttpContext.Session.SetString("Mensaje",respuesta.Mensaje);
                HttpContext.Session.SetString("CodigoRespuesta", Convert.ToString(respuesta.CodigoRespuesta));
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
