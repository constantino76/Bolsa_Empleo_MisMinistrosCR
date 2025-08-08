using System.Drawing.Text;
using WebMisMinistros.Models;
using System.Text;
using WebMisMinistros.Repositorios.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using WebMisMinistros.MensajesHttp;
using System.Net.Http;

namespace WebMisMinistros.Repositorios.Services
{
    public class RolService : IRol
    { 
        public async Task<List<Rol>> getRoles()
        {
            List<Rol> listroles = null;
            string url = "https://localhost:7178/api/Roles/";

            using (var httpclient = new HttpClient()) {

               var response= await httpclient.GetAsync(url+"getRoles/");
                if (response.IsSuccessStatusCode) {
                    var jsonContent = await response.Content.ReadAsStringAsync();   

                    listroles = JsonConvert.DeserializeObject<List<Rol>>(jsonContent);
                }
            }
                return listroles;
        }

        public async Task<Respuesta> InsertarRol(Rol rol, string token)
        {
            Respuesta resp = new Respuesta();

            string url = "https://localhost:7178/api/Roles/CrearRol/";
            string jSon =JsonConvert.SerializeObject(rol);

            using (var httpclient = new HttpClient()) {

                // Agregamos en la solicitud de la cabezera el token
                httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);



                var content = new StringContent(jSon, Encoding.UTF8, "application/json");

                var response =await httpclient.PostAsync(url, content);
                //obtenemos las respuesta de la peticion desde la api
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    resp.Mensaje = "Recurso creado  correctamente";
                    resp.CodigoRespuesta =Convert.ToInt32(Respuesta.TipoRespuesta.OK);   
                var respuesta=response.Content.ReadAsStringAsync();
                    Console.WriteLine("respuesta:");
                
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) {
                    var respuesta = response.Content.ReadAsStringAsync();
                    Console.WriteLine(respuesta);
                
                }
            }
                

            return   resp;
           
        }
    }
}
