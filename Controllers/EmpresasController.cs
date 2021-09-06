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
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmpresasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {
            var Empresas = await context.Empresas.ToListAsync();
            return Empresas;
        }

        [HttpGet("{id}", Name = "ObtenerEmpresas")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            var Empresa = await context.Empresas.FirstOrDefaultAsync(x => x.id == id);

            if (Empresa == null)
            {
                return NotFound();
            }

            return Empresa;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empresa EmpresaCreacion)
        {
            context.Add(EmpresaCreacion);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerEmpresas", new { id = EmpresaCreacion.id }, EmpresaCreacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Empresa EmpresaActualizacion)
        {
            EmpresaActualizacion.id = id;
            context.Entry(EmpresaActualizacion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> Delete(int id)
        {
            var Empresaid = await context.Empresas.Select(x => x.id).FirstOrDefaultAsync(x => x == id);

            if (Empresaid == default(int))
            {
                return NotFound();
            }
            context.Remove(new Empresa { id = Empresaid });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}