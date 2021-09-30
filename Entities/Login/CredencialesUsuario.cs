using System.ComponentModel.DataAnnotations;

namespace WebApiALMTextil.Entities.Login
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}