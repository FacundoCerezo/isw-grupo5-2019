using System.Data.Entity;

namespace DeliverEat.Models
{
    internal class DeliverEatContext : DbContext
    {
        public DeliverEatContext() : base("DeliverEatContext")
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
    }
}