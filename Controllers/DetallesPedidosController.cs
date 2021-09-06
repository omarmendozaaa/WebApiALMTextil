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
    public class DetallePedidosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DetallePedidosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> Get()
        {
            var DetallePedidos = await context.DetallePedidos.ToListAsync();
            return DetallePedidos;
        }

        [HttpGet("{id}", Name = "ObtenerDetallePedidos")]
        public async Task<ActionResult<DetallePedido>> Get(int id)
        {
            var DetallePedido = await context.DetallePedidos.FirstOrDefaultAsync(x => x.id == id);

            if (DetallePedido == null)
            {
                return NotFound();
            }

            return DetallePedido;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetallePedido DetallePedidoCreacion)
        {
            context.Add(DetallePedidoCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerDetallePedidos", new { id = DetallePedidoCreacion.id }, DetallePedidoCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetallePedido DetallePedidoActualizacion)
        {
            DetallePedidoActualizacion.id = id;
            context.Entry(DetallePedidoActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetallePedido>> Delete(int id)
        {
            var DetallePedidoid = await context.DetallePedidos.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (DetallePedidoid == default(int))
            {
                return NotFound();
            }
            context.Remove(new DetallePedido { id = DetallePedidoid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}