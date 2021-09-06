using System;

namespace WebApiALMTextil.Entities
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int id_Pedido { get; set; }
        public int id_Prenda { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        //Relaciones
        public Prenda Prenda { get; set; }
    }
}