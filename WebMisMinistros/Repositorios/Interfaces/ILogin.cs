using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebMisMinistros.Models;

namespace WebMisMinistros.Repositorios.Interfaces
{
    public interface ILogin
    {
        public Task<JwTokenResponse> Login(Login_ user);
        public Task<IAsyncResult> Logout();

    }
}
