namespace WebApiALMTextil.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public int id_Usuario { get; set; }
        public int id_Local { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string ruc { get; set; }
        //Relaciones
        public Usuario Usuario { get; set; }
        public Local Local { get; set; }
    }
}