using Microsoft.AspNetCore.Mvc;

namespace WebMisMinistros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dasboard()
        {
            return View();
        }
    }
}
