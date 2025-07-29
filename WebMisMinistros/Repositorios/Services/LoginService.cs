using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Repositorios.implementacion
{
    public class LoginService : ILogin
    {   //recordar debe terminar con barra inclinada al final de la url para que trabaje 
        private const string url = "https://localhost:7178/api/Acceso/auth/login/";
        public async Task<JwTokenResponse> Login(Login_ user)
        {


            if (user == null)
            {

                return null;

            }

            string json = JsonConvert.SerializeObject(user);

            using (var httpClient = new HttpClient())
            {

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

                //deserializamos el toquen
                if (response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var jsonobject = JsonConvert.DeserializeObject<JwTokenResponse>(jsondata);

                    if (jsonobject != null) return jsonobject;

                }
                //manejamos los diferentes  errores 
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core y asi saber que hacer
                    var problemJson = await response.Content.ReadAsStringAsync();

                    // adicionalmente imprimimos el error 
                    Console.WriteLine("Error 400, ProblemDetails de la API:");
                    Console.WriteLine(problemJson);

                    throw new Exception($"BadRequest: {problemJson}");
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Credenciales inválidas");
                }

                response.EnsureSuccessStatusCode();
            }
            return null;
        }

        public Task<IAsyncResult> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
