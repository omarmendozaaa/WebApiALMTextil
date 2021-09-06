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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var Clientes = await context.Clientes.ToListAsync();
            return Clientes;
        }

        [HttpGet("{id}", Name = "ObtenerClientes")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var Cliente = await context.Clientes.FirstOrDefaultAsync(x => x.id == id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Cliente;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente ClienteCreacion)
        {
            context.Add(ClienteCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerClientes", new { id = ClienteCreacion.id }, ClienteCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente ClienteActualizacion)
        {
            ClienteActualizacion.id = id;
            context.Entry(ClienteActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var Clienteid = await context.Clientes.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Clienteid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Cliente { id = Clienteid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}