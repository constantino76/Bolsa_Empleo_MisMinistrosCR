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
        // GET: AccesoController
        public AccesoController(IUsuario iusuario, ILogin ilogin) { 
        
        _iusuario = iusuario;

            _ilogin = ilogin;
        
        }



        [AllowAnonymous]

        public async Task<ActionResult> Login() {
            return View();
        
        
        }

        // GET: AccesoController/Details/5
        [HttpPost]
        public  async Task <ActionResult> Login(Login_ user)
        {
            string Rol = "";

            if (String.IsNullOrEmpty(user.Correo) ||String.IsNullOrEmpty(user.Clave)) {


                return RedirectToAction("Login");
            
            }

            try {
                // recibe el objeto token
               var jwtk=await  _ilogin.Login(user);
                if(jwtk!=null)
                HttpContext.Session.SetString("jwtk", jwtk.token);
                
                }
            
             catch {

               
            }
        

            return RedirectToAction("Index","Home");
        }

        // GET: AccesoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesoController/Create
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

        // GET: AccesoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccesoController/Edit/5
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

        // GET: AccesoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccesoController/Delete/5
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
