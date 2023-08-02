using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly DataContext dc;

        public EstadoController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Estado>> GetAll()
        {
            var listaEstado = new List<Estado>();

            try
            {
                listaEstado = await dc.Estado.OrderBy(x => x.IdEstado).ToListAsync();
                return Ok(listaEstado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstadoById(int id)
        {
            var estado = new Estado();

            try
            {
                estado = await dc.Estado.FindAsync(id);
                return Ok(estado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
