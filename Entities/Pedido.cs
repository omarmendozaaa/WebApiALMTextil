using System;

namespace WebApiALMTextil.Entities
{
    public class Pedido
    {
        public int id { get; set; }
        public int id_Cliente { get; set; }
        public int id_Empresa { get; set; }
        public int id_Local { get; set; }
        public int id_Medidas { get; set; }
        public int id_DetallePedido { get; set; }
        public DateTime fecha_Entrega { get; set; }
        public DateTime created_at { get; set; }
        //Relaciones
        public Cliente Cliente { get; set; }  
        public Empresa Empresa { get; set; }
        public Local Local { get; set; }
        public Medidas Medidas { get; set; }
        public DetallePedido DetallePedido { get; set; }
    }
}