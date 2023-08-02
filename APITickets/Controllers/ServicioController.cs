using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly DataContext dc;

        public ServicioController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Servicio>> GetAll()
        {
            var listaServicio = new List<Servicio>();

            try
            {
                listaServicio = await dc.Servicio.OrderBy(x => x.IdServicio).ToListAsync();
                return Ok(listaServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicioById(int id)
        {
            var servicio = new Servicio();

            try
            {
                servicio = await dc.Servicio.FindAsync(id);
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
