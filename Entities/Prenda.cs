namespace WebApiALMTextil.Entities
{
    public class Prenda
    {
        public int id { get; set; }
        public int id_Tela { get; set; }
        public int id_tipoPrenda { get; set; }
        //Relaciones
        public Tela Tela { get; set; }
        public TipoPrenda TipoPrenda { get; set; }
    }
}