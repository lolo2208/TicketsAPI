using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DataContext dc;

        public RolController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Rol>> GetAll()
        {
            var listaRol = new List<Rol>();

            try
            {
                listaRol = await dc.Rol.OrderBy(x => x.IdRol).ToListAsync();
                return Ok(listaRol);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRolById(int id)
        {
            var rol = new Rol();

            try
            {
                rol = await dc.Rol.FindAsync(id);
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}
