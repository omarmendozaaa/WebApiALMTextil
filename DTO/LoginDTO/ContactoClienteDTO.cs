using Microsoft.AspNetCore.Identity;

namespace WebApiALMTextil.DTO.LoginDTO
{
    public class ContactoClienteDTO
    {
        public string direccion1 { get; set; }
        public string direccion2 { get; set; }
        public string ciudad { get; set; }
        public string codigo_postal { get; set; }
        public string telefono { get; set; }
    }
}
