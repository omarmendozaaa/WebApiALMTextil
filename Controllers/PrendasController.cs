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
    public class PrendasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PrendasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prenda>>> Get()
        {
            var Prendas = await context.Prendas.ToListAsync();
            return Prendas;
        }

        [HttpGet("{id}", Name = "ObtenerPrendas")]
        public async Task<ActionResult<Prenda>> Get(int id)
        {
            var Prenda = await context.Prendas.FirstOrDefaultAsync(x => x.id == id);

            if (Prenda == null)
            {
                return NotFound();
            }

            return Prenda;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Prenda PrendaCreacion)
        {
            context.Add(PrendaCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPrendas", new { id = PrendaCreacion.id }, PrendaCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Prenda PrendaActualizacion)
        {
            PrendaActualizacion.id = id;
            context.Entry(PrendaActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Prenda>> Delete(int id)
        {
            var Prendaid = await context.Prendas.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Prendaid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Prenda { id = Prendaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}