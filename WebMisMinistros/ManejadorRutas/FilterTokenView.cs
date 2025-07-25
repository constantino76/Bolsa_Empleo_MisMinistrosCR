using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMisMinistros.ManejadorRutas
{
    public class FilterTokenView : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
           // var token = context.HttpContext.Session.GetString("jwtk"); //jwtk

           var controller = context.RouteData.Values["controller"]?.ToString()?.ToLower();
            var action = context.RouteData.Values["action"]?.ToString()?.ToLower();


           var token = context.HttpContext.Session.GetString("jwtk");

            // Excluir Login y Acceso para evitar bucle
            if ((controller == "acceso" && action == "login") ||
                (controller == "acceso" && action == "validarusuario"))
            {
                base.OnActionExecuting(context);
                return;
            }
            if ((controller == "home" && action == "dasboard"))
            {
                base.OnActionExecuting(context);
                return;
            }
            if ((controller == "usuarios" && action == "crearnuevacuenta") ||
                (controller == "usuarios" && action == "validarusuario"))
            {
                base.OnActionExecuting(context);
                return;
            }
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("Login", "Acceso", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }

}