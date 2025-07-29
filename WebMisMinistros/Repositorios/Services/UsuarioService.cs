using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net;
using System.Text;
using WebMisMinistros.MensajesHttp;
using WebMisMinistros.Models;
using WebMisMinistros.Repositorios.Interfaces;

namespace WebMisMinistros.Repositorios.implementacion
{
    public class UsuarioService : IUsuario
    {

        private string url = "";


        public async Task<Respuesta> crearUsuario(Usuario usuario, string token)
        {
            Respuesta respond = new Respuesta();// instanciamos la clase Respuesta para luego usar sus propiedades 

            string json = JsonConvert.SerializeObject(usuario);// serializamos el objeto usuario

            using (var httpcliente = new HttpClient())// inicializamos el HttpCliente para usuar sus metodos 
            {
                // Agregamos en la solicitud de la cabezera el token
                httpcliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
               // httpcliente.BaseAddress= new Uri("https://localhost:7178/api/");
               
                
                url = "https://localhost:7178/api/Usuarios/registerUser/";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpcliente.PostAsync(url, content);// obtenemos la respuesta 

                if (response.StatusCode == HttpStatusCode.Unauthorized)// captura la respuesta cuando no se han proporcionado las credenciales o estas son invalidas 
                {    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core
                    string problemJson = await response.Content.ReadAsStringAsync();
                    respond.Mensaje = problemJson;
                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.Unauthorized);


                }


                if (response.StatusCode == HttpStatusCode.BadRequest)//  captura la respuesta cuando el modelo tiene datos faltantes o que no cumplen las reglas 
                {
                    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core
                   
                    respond.Mensaje = await response.Content.ReadAsStringAsync(); ;
                    respond.CodigoRespuesta =Convert.ToInt32(Respuesta.TipoRespuesta.BackRequest);

                    // Opcional: imprímelo en consola o lanza una excepción con ese texto
                    Console.WriteLine("Error 400, problemas en el modelo de datos :");
                    Console.WriteLine(respond.Mensaje);

                    throw new Exception($"BadRequest: {respond.Mensaje}");
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();

                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.Forbidden);

                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();

                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.NotFound);

                }

                if (response.StatusCode==HttpStatusCode.OK) {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();
                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.Forbidden);

                }
            }
          



            return respond;
        }



        public async Task<Respuesta> CrearNuevoUsuario(Usuario usuario)
        {

            Respuesta respond = new Respuesta();

            url = "https://localhost:7178/api/Usuarios/AbrirCuentaUsuario/";
            string json = JsonConvert.SerializeObject(usuario);
            using (var httpcliente = new HttpClient())
            {


                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpcliente.PostAsync(url, content);// obtenemos la respuesta 

                if (response.StatusCode == HttpStatusCode.Unauthorized)// captura la respuesta cuando no se han proporcionado las credenciales o estas son invalidas 
                {    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core
                    string problemJson = await response.Content.ReadAsStringAsync();
                    respond.Mensaje = problemJson;
                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.Unauthorized);


                }


                if (response.StatusCode == HttpStatusCode.BadRequest)//  captura la respuesta cuando el modelo tiene datos faltantes o que no cumplen las reglas 
                {
                    // Lee el cuerpo completo del problema (ProblemDetails) que envía ASP.NET Core

                    respond.Mensaje = await response.Content.ReadAsStringAsync(); ;
                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.BackRequest);

                    // Opcional: imprímelo en consola o lanza una excepción con ese texto
                    Console.WriteLine("Error 400, problemas en el modelo de datos :");
                    Console.WriteLine(respond.Mensaje);

                    throw new Exception($"BadRequest: {respond.Mensaje}");
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();

                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.Forbidden);

                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();

                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.NotFound);

                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    respond.Mensaje = await response.Content.ReadAsStringAsync();
                    respond.CodigoRespuesta = Convert.ToInt32(Respuesta.TipoRespuesta.OK);

                }
            }

            return respond;

                }
                // o en caso que se creo el recurso que devuelva 2
        



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
