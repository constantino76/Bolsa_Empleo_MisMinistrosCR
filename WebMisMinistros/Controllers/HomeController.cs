using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMisMinistros.Models;

namespace WebMisMinistros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() {

            return View();
        
        }
        public ActionResult CrearUsuario()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario(Usuario usuario) {

            if (usuario != null)
            {


                return RedirectToAction("index");


            }


            try { 
            
            
            }
            catch { 
            }
            return View();
        
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
