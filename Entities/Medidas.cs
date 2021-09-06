namespace WebApiALMTextil.Entities
{
    public class Medidas
    {
        public int id { get; set; }
        public int id_Cliente { get; set; }
        public string datos { get; set; }
        //Relaciones
        public Cliente Cliente { get; set; }
    }
}