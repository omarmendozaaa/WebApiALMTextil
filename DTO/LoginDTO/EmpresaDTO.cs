using Microsoft.AspNetCore.Identity;

namespace WebApiALMTextil.DTO.LoginDTO
{
    public class EmpresaDTO
    {
        public string nombre { get; set; }
        public string email { get; set; }
        public string ruc { get; set; }
    }
}