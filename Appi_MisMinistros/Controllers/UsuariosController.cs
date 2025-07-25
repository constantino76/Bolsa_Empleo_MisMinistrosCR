using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appi_MisMinistros.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _iusuario;


        public UsuariosController(IUsuario iusuario) {

            _iusuario = iusuario;
        
        }
        // GET: api/<UsuariosController>
       
        [HttpPost("registerUser")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> InsertarUsuario([FromBody] Usuario usuario)
        { // validamos el modelo
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            
            
            
            }

            await _iusuario.InsertarUsuario(usuario); 
            return Ok("Registro Agregado");
        }

        [HttpPost("AbrirCuentaUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult> AbrirNuevaCuenta([FromBody] Usuario nuevoregistro) {

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }
            await _iusuario.InsertarUsuario(nuevoregistro);
          return Ok("Registro Agregado");

        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
