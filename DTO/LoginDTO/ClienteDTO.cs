using Microsoft.AspNetCore.Identity;

namespace WebApiALMTextil.DTO.LoginDTO
{
    public class ClienteDTO
    {
        public string nombre_Usuario { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public ContactoClienteDTO ContactoCliente { get; set; }
    }
}