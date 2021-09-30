using Microsoft.AspNetCore.Identity;

namespace WebApiALMTextil.Entities
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre_Usuario { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string UsuarioId { get; set; }
        public int ContactoClienteId { get; set; }
        //Relaciones
        public IdentityUser Usuario { get; set; }
        public ContactoCliente MyProperty { get; set; }
    }
}