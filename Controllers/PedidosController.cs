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
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PedidosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var Pedidos = await context.Pedidos.ToListAsync();
            return Pedidos;
        }

        [HttpGet("{id}", Name = "ObtenerPedidos")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var Pedido = await context.Pedidos.FirstOrDefaultAsync(x => x.id == id);

            if (Pedido == null)
            {
                return NotFound();
            }

            return Pedido;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pedido PedidoCreacion)
        {
            context.Add(PedidoCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPedidos", new { id = PedidoCreacion.id }, PedidoCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pedido PedidoActualizacion)
        {
            PedidoActualizacion.id = id;
            context.Entry(PedidoActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Delete(int id)
        {
            var Pedidoid = await context.Pedidos.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Pedidoid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Pedido { id = Pedidoid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}