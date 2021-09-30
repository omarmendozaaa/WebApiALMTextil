using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiALMTextil;
using WebApiALMTextil.DTO.LoginDTO;
using WebApiALMTextil.Entities;

namespace WebApiALMTextil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var Clientes = await context.Clientes.ToListAsync();
            return mapper.Map<List<ClienteDTO>>(Clientes);
        }

        [HttpGet("{id}", Name = "ObtenerClientes")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var Cliente = await context.Clientes.FirstOrDefaultAsync(x => x.id == id);
            var ClienteDTO = mapper.Map<ClienteDTO>(Cliente);
            if (Cliente == null)
            {
                return NotFound();
            }
            return ClienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO ClienteCreacionDTO, string UsuarioId)
        {
            var ClienteCreacion = mapper.Map<Cliente>(ClienteCreacionDTO);
            ClienteCreacion.UsuarioId = UsuarioId;
            context.Add(ClienteCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerClientes", new { id = ClienteCreacion.id }, ClienteCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO ClienteActualizacionDTO)
        {
            var ClienteActualizacion = mapper.Map<Cliente>(ClienteActualizacionDTO);
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