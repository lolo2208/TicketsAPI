using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext dc;

        public UsuarioController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetAll()
        {
            var listaUsuario = new List<Usuario>();

            try
            {
                listaUsuario = await dc.Usuario.OrderBy(x => x.IdUsuario).ToListAsync();
                return Ok(listaUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = new Usuario();

            try
            {
                usuario = await dc.Usuario.FindAsync(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{correo}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByCorreo(string correo)
        {
            var usuario = new Usuario();

            try
            {
                usuario = await dc.Usuario.FirstOrDefaultAsync(x => x.Correo == correo);
                if(usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(usuario);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario([FromBody]Usuario usuario)
        {
            try
            {
                dc.Usuario.Add(usuario);
                await dc.SaveChangesAsync();
                return Ok("Usuario guardado");

            }
            catch(Exception ex){
                
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioObtained = dc.Usuario.Find(usuario.IdUsuario);

                if(usuarioObtained == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                else{
                    //se valida que no se coloque un email igual
                    var usuarioValidation = dc.Usuario
                                                .Where(x => x.Correo == usuario.Correo && x.IdUsuario != usuario.IdUsuario)
                                                .FirstOrDefault();

                    if (usuarioValidation != null)
                        return NotFound("El correo está en uso");

                    dc.Entry(usuarioObtained).CurrentValues.SetValues(usuario);
                    await dc.SaveChangesAsync();

                    return Ok("Usuario actualizado");
                }
              
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }
}
