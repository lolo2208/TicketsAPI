using APITickets.Model;
using APITickets.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITickets.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PresetController : ControllerBase
    {
        private readonly DataContext dc;

        public PresetController(DataContext dataContext)
        {
            dc = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Preset>> GetAll()
        {
            var listaPreset = new List<Preset>();

            try
            {
                listaPreset = await dc.Preset.OrderBy(x => x.IdPreset).ToListAsync();
                return Ok(listaPreset);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Preset>> GetPresetById(int id)
        {
            var preset = new Preset();

            try
            {
                preset = await dc.Preset.FindAsync(id);
                return Ok(preset);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult> CreatePreset([FromBody] Preset Preset)
        {
            try
            {
                dc.Preset.Add(Preset);
                await dc.SaveChangesAsync();
                return Ok("Preset guardado");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdatePreset([FromBody] Preset Preset)
        {
            try
            {
                var presetObtained = dc.Preset.Find(Preset.IdPreset);

                if (presetObtained == null)
                {
                    return NotFound("Preset no encontrado");
                }
                else
                {
                    //se valida que no se coloque una sigla igual
                    var presetValidation = dc.Preset
                                                .Where(x => x.SiglaPreset == Preset.SiglaPreset&& x.IdPreset != Preset.IdPreset)
                                                .FirstOrDefault();

                    if (presetValidation != null)
                        return NotFound("El codigo está en uso");

                    dc.Entry(presetObtained).CurrentValues.SetValues(Preset);
                    await dc.SaveChangesAsync();

                    return Ok("Preset actualizado");
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePreset(int id)
        {            
            try
            {
                var presetObtained = dc.Preset.Find(id);

                if (presetObtained == null)
                    return NotFound("Preset no existe");

                dc.Preset.Remove(presetObtained);
                await dc.SaveChangesAsync();

                return Ok("Preset eliminado");

            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
