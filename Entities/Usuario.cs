using System;

namespace WebApiALMTextil.Entities
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre_Usuario { get; set; }
        public string email { get; set; }
        public int idtipo_Doc { get; set; }
        public DateTime created_at { get; set; }
        //Relaciones
        public TipoDoc TipoDoc { get; set; }
    }
}