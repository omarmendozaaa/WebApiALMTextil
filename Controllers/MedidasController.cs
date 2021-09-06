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
    public class MedidasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MedidasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidas>>> Get()
        {
            var Medidas = await context.Medidas.ToListAsync();
            return Medidas;
        }

        [HttpGet("{id}", Name = "ObtenerMedidas")]
        public async Task<ActionResult<Medidas>> Get(int id)
        {
            var Medida = await context.Medidas.FirstOrDefaultAsync(x => x.id == id);

            if (Medida == null)
            {
                return NotFound();
            }

            return Medida;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Medidas MedidaCreacion)
        {
            context.Add(MedidaCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerMedidas", new { id = MedidaCreacion.id }, MedidaCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Medidas MedidaActualizacion)
        {
            MedidaActualizacion.id = id;
            context.Entry(MedidaActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Medidas>> Delete(int id)
        {
            var Medidaid = await context.Medidas.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Medidaid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Medidas { id = Medidaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}