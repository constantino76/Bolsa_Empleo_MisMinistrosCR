using Appi_MisMinistros.Data;
using Appi_MisMinistros.Models;
using Appi_MisMinistros.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appi_MisMinistros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRol _irolservice;
        public RolesController(IRol irolservice) {
        _irolservice = irolservice; 
        
        }
        [HttpPost("CrearRol")]
        [Authorize(Roles = "Administrador")]


        public async Task<IActionResult> CrearRol(Rol rol) {

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);        
            
            }
         var rolresult=  await _irolservice.AgregarRol(rol);
           
                return Ok(new { Mensaje= "Rol creado",

                    Rol = new
                    {
                        rol.IdRol,
                        rol.RolNombre
                    } });
            
            
        
        }

        [AllowAnonymous]
        [HttpGet("getRoles")]
        public async Task<List<Rol>> getRoles() {
        
        List<Rol>listroles =await _irolservice.getRoles();  
return listroles;   
        
        }

    }
}
