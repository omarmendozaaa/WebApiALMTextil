using Microsoft.EntityFrameworkCore;
using WebApiALMTextil.Entities;

namespace WebApiALMTextil
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContactoUsuario> ContactoUsuarios { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<Tela> Telas { get; set; }
        public DbSet<TipoDoc> TipoDocs { get; set; }
        public DbSet<TipoPrenda> TipoPrendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}