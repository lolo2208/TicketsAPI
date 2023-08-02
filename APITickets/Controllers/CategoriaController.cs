using APITickets.Context;
using APITickets.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext dc;

        public CategoriaController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Categoria>> GetAll()
        {
            var listaCategoria = new List<Categoria>();

            try
            {
                listaCategoria = await dc.Categoria.OrderBy(x => x.IdCategoria).ToListAsync();
                return Ok(listaCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            var categoria = new Categoria();

            try
            {
                categoria = await dc.Categoria.FindAsync(id);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

