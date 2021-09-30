namespace WebApiALMTextil.Entities
{
    public class Local
    {
        public int id { get; set; }
        public string direccion { get; set; }
        public int nombre_Sede { get; set; }
        public int id_empresa {  get; set; }
        //Relaciones
        public Empresa Empresa { get; set; }
    }
}