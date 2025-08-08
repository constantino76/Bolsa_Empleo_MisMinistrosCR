using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMisMinistros.MensajesHttp;
using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRol _irol;

        public RolesController(IRol irol)
        {


            _irol = irol;


        }


        // metodo para  traer todos los roles a la vista 
        public async Task< IActionResult> Index()
        {
            List<Rol> roles = await _irol.getRoles();   

            return View(roles);
        }



        public ActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromForm] Rol rol) {



            if (!ModelState.IsValid) { 
            
            return BadRequest(ModelState);
            
            }
            string token = HttpContext.Session.GetString("jwtk");
            Respuesta  result =await _irol.InsertarRol(rol,token);
            
            return RedirectToAction("CrearRol");
       
        
        
        }

        // GET: RolesController1/Details/5
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // GET: RolesController1/Create
        

        // POST: RolesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
