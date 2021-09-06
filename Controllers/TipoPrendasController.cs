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
    public class TipoPrendasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TipoPrendasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPrenda>>> Get()
        {
            var TipoPrendas = await context.TipoPrendas.ToListAsync();
            return TipoPrendas;
        }

        [HttpGet("{id}", Name = "ObtenerTipoPrendas")]
        public async Task<ActionResult<TipoPrenda>> Get(int id)
        {
            var TipoPrenda = await context.TipoPrendas.FirstOrDefaultAsync(x => x.id == id);

            if (TipoPrenda == null)
            {
                return NotFound();
            }

            return TipoPrenda;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoPrenda TipoPrendaCreacion)
        {
            context.Add(TipoPrendaCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerTipoPrendas", new { id = TipoPrendaCreacion.id }, TipoPrendaCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoPrenda TipoPrendaActualizacion)
        {
            TipoPrendaActualizacion.id = id;
            context.Entry(TipoPrendaActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoPrenda>> Delete(int id)
        {
            var TipoPrendaid = await context.TipoPrendas.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (TipoPrendaid == default(int))
            {
                return NotFound();
            }
            context.Remove(new TipoPrenda { id = TipoPrendaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}