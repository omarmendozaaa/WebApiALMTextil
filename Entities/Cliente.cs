namespace WebApiALMTextil.Entities
{
    public class Cliente
    {
        public int id { get; set; }
        public int id_Usuario { get; set; }
        public string nombre_Usuario { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        //Relaciones
        public Usuario Usuario { get; set; }
    }
}