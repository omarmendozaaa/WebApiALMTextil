using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiALMTextil;
using WebApiALMTextil.Entities;

namespace WebApiALMTextil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TipoDocsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDoc>>> Get()
        {
            var TipoDocs = await context.TipoDocs.ToListAsync();
            return TipoDocs;
        }

        [HttpGet("{id}", Name = "ObtenerTipoDocs")]
        public async Task<ActionResult<TipoDoc>> Get(int id)
        {
            var TipoDoc = await context.TipoDocs.FirstOrDefaultAsync(x => x.id == id);

            if (TipoDoc == null)
            {
                return NotFound();
            }

            return TipoDoc;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoDoc TipoDocCreacion)
        {
            context.Add(TipoDocCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerTipoDocs", new { id = TipoDocCreacion.id }, TipoDocCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoDoc TipoDocActualizacion)
        {
            TipoDocActualizacion.id = id;
            context.Entry(TipoDocActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDoc>> Delete(int id)
        {
            var TipoDocid = await context.TipoDocs.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (TipoDocid == default(int))
            {
                return NotFound();
            }
            context.Remove(new TipoDoc { id = TipoDocid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}