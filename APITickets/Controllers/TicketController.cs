using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DataContext dc;

        public TicketController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Ticket>> GetAll()
        {
            var listaTicket = new List<Ticket>();

            try
            {
                listaTicket = await dc.Ticket.OrderBy(x => x.IdTicket).ToListAsync();
                return Ok(listaTicket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = new Ticket();

            try
            {
                ticket = await dc.Ticket.FindAsync(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            try
            {                
                dc.Ticket.Add(ticket);
                await dc.SaveChangesAsync();
                return Ok("Ticket guardado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateTicket([FromBody] Ticket ticket)
        {
            try
            {
                var ticketObtained = dc.Ticket.Find(ticket.IdTicket);

                if (ticketObtained == null)
                {
                    return NotFound("Ticket no encontrado");
                }
                else
                {
                    //se valida que no se coloque una sigla igual
                    var ticketValidation = dc.Ticket
                                                .Where(x => x.CodTicket == ticket.CodTicket && x.IdTicket != ticket.IdTicket)
                                                .FirstOrDefault();

                    if (ticketValidation != null)
                        return NotFound("El codigo está en uso");

                    dc.Entry(ticketObtained).CurrentValues.SetValues(ticket);
                    await dc.SaveChangesAsync();

                    return Ok("Ticket actualizado");
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AttendTicket([FromBody]Ticket ticket, int id)
        {
            try
            {
                var ticketObtained = dc.Ticket.Find(id);


                if (ticketObtained == null)
                {
                    return NotFound("Ticket no encontrado");
                }
                else
                {
                    ticketObtained.ComentarioSolucion = ticket.ComentarioSolucion;
                    ticketObtained.IdEstado = 2;
                    await dc.SaveChangesAsync();

                    return Ok("Ticket actualizado");
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            try
            {
                var ticketObtained = dc.Ticket.Find(id);

                if (ticketObtained == null)
                    return NotFound("Ticket no existe");

                dc.Ticket.Remove(ticketObtained);
                await dc.SaveChangesAsync();

                return Ok("Ticket eliminado");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
