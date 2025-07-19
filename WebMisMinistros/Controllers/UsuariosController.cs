using Microsoft.AspNetCore.Mvc;
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
        public UsuariosController(ILogger<UsuariosController> logger,IUsuario iusuario)
        {
            _logger = logger;
            _iusuario = iusuario;
        }

        public IActionResult Index() {

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
        public List<Rol> GetRoles() { 
        
        List<Rol> roles = new List<Rol>();

            roles.Add(new Rol() { IdRol=1,RolNombre="Administrador" });

            roles.Add(new Rol() { IdRol = 2, RolNombre = "Developer" });
            return roles;
        }
       
        [HttpPost]
        public async Task<IActionResult> CrearUsuario(UsuarioViewModel usuarioviewmodel ,int IdRol ) {

            if (usuarioviewmodel == null)
            {


                return RedirectToAction("index");


            }


            try {
                Usuario usuario = new Usuario() {

                    IdUsuario = usuarioviewmodel.IdUsuario,
                    Nombre = usuarioviewmodel.Nombre,
                    PrimerApellido=usuarioviewmodel.PrimerApellido,
                    SegundoApellido=usuarioviewmodel.SegundoApellido,
                    Correo=usuarioviewmodel.Correo,
                    Clave=usuarioviewmodel.Clave
                
                };

               string token= HttpContext.Session.GetString("jwtk");

              await   _iusuario.crearUsuario(usuario, token);
            }
            catch { 
            }
            return  RedirectToAction("CrearUsuario");
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
