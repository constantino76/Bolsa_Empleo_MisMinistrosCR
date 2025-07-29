namespace WebMisMinistros.MensajesHttp
{
    public class Respuesta
    {
        public string Mensaje { get; set; }
        public int CodigoRespuesta { get; set; }
        public enum TipoRespuesta
        {

            OK = 200,// 
            BackRequest = 400,// datos faltantes o incorectos
            Forbidden = 403,// No tiene  permiso de realizar dicha accion
            Unauthorized = 401,// las credenciales estan vencidads o no se han proporcionado
            NotFound = 404// Url no se encontro
        }
    }
}
