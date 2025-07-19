using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Repositorios.implementacion
{
    public class UsuarioService : IUsuario
    {
       private string url = "https://localhost:7178/api/Usuarios/registerUser/";
       // private string url = "https://localhost:7178/api/Acceso/registerUser/";
        public async  Task<bool> crearUsuario(Usuario usuario ,string token)
        {
          
            string json = JsonConvert.SerializeObject(usuario);
            using (var httpcliente = new HttpClient()) {
                 httpcliente.DefaultRequestHeaders.Authorization =  new System.Net.Http.Headers
                                                                    .AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(json,Encoding.UTF8,"application/json");
                var response = await httpcliente.PostAsync(url, content);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Credenciales inválidas");
                }


                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core
                    var problemJson = await response.Content.ReadAsStringAsync();

                    // Opcional: imprímelo en consola o lanza una excepción con ese texto
                    Console.WriteLine("Error 400, problemas en el modelo de datos :");
                    Console.WriteLine(problemJson);

                    throw new Exception($"BadRequest: {problemJson}");
                }
                if (response.StatusCode==HttpStatusCode.Forbidden) { }
            }
                if (usuario == null) return false;


           
            return true;
        }
        public Task<Usuario> BuscarUsuario(string correo, string clave)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> upDateUsuario(Usuario userUpdate, string token)
        {
            throw new NotImplementedException();
        }
    }
}
