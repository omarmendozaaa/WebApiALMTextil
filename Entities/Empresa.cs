using Microsoft.AspNetCore.Identity;

namespace WebApiALMTextil.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string ruc { get; set; }
        public string UsuarioId { get; set; }
        //Relaciones
        public IdentityUser Usuario { get; set; }
    }
}