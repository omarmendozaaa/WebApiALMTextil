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
    public class LocalesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LocalesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> Get()
        {
            var Locals = await context.Locales.ToListAsync();
            return Locals;
        }

        [HttpGet("{id}", Name = "ObtenerLocals")]
        public async Task<ActionResult<Local>> Get(int id)
        {
            var Local = await context.Locales.FirstOrDefaultAsync(x => x.id == id);

            if (Local == null)
            {
                return NotFound();
            }

            return Local;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Local LocalCreacion)
        {
            context.Add(LocalCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerLocals", new { id = LocalCreacion.id }, LocalCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Local LocalActualizacion)
        {
            LocalActualizacion.id = id;
            context.Entry(LocalActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Local>> Delete(int id)
        {
            var Localid = await context.Locales.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Localid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Local { id = Localid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}