using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiALMTextil.DTO.LoginDTO;
using WebApiALMTextil.Entities;
using WebApiALMTextil.Entities.Login;

namespace WebApiALMTextil.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost("RegistrarCliente")]
        public async Task<ActionResult> RegistarCliente(CredencialesUsuario credenciales, ClienteDTO ClienteCreacionDTO)
        {
            var registroresult = RegistrarUsuario(credenciales).Result;
            if (registroresult == true)
            {
                var usuario = await userManager.FindByEmailAsync(credenciales.Email);
                var ClienteCreacion = mapper.Map<Cliente>(ClienteCreacionDTO);
                ClienteCreacion.UsuarioId = usuario.Id;
                context.Add(ClienteCreacion);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("ObtenerClientes", new { id = ClienteCreacion.id }, ClienteCreacion);
            }
            else
            {
                return BadRequest(RegistrarUsuario(credenciales).Result);
            }
        }
        [HttpPost("RegistrarEmpresa")]
        public async Task<ActionResult> RegistrarEmpresa(CredencialesUsuario credenciales, EmpresaDTO EmpresaCreacionDTO)
        {
            var registroresult = RegistrarUsuario(credenciales).Result;
            if (registroresult == true)
            {
                var usuario = await userManager.FindByEmailAsync(credenciales.Email);
                var EmpresaCreacion = mapper.Map<Empresa>(EmpresaCreacionDTO);
                EmpresaCreacion.UsuarioId = usuario.Id;
                context.Add(EmpresaCreacion);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("ObtenerEmpresas", new { id = EmpresaCreacion.id }, EmpresaCreacion);
            }
            else
            {
                return BadRequest(RegistrarUsuario(credenciales).Result);
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email, credencialesUsuario.Password, isPersistent: false, false);
            if (resultado.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }
        }
        [HttpPost]
        public async Task<bool> RegistrarUsuario(CredencialesUsuario credenciales)
        {
            var usuario = new IdentityUser { UserName = credenciales.Email, Email = credenciales.Email };
            var result = await userManager.CreateAsync(usuario, credenciales.Password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}