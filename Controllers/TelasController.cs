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
    public class TelasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TelasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tela>>> Get()
        {
            var Telas = await context.Telas.ToListAsync();
            return Telas;
        }

        [HttpGet("{id}", Name = "ObtenerTelas")]
        public async Task<ActionResult<Tela>> Get(int id)
        {
            var Tela = await context.Telas.FirstOrDefaultAsync(x => x.id == id);

            if (Tela == null)
            {
                return NotFound();
            }

            return Tela;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tela TelaCreacion)
        {
            context.Add(TelaCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerTelas", new { id = TelaCreacion.id }, TelaCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tela TelaActualizacion)
        {
            TelaActualizacion.id = id;
            context.Entry(TelaActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tela>> Delete(int id)
        {
            var Telaid = await context.Telas.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Telaid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Tela { id = Telaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}