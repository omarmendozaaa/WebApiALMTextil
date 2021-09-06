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
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsuariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var Usuarios = await context.Usuarios.ToListAsync();
            return Usuarios;
        }

        [HttpGet("{id}", Name = "ObtenerUsuarios")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var Usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.id == id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario UsuarioCreacion)
        {
            context.Add(UsuarioCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerUsuarios", new { id = UsuarioCreacion.id }, UsuarioCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario UsuarioActualizacion)
        {
            UsuarioActualizacion.id = id;
            context.Entry(UsuarioActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var Usuarioid = await context.Usuarios.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Usuarioid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Usuario { id = Usuarioid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}