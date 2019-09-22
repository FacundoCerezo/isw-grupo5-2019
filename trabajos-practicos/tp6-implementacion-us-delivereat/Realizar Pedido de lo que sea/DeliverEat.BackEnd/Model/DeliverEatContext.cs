using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model
{
	internal class DeliverEatContext : DbContext
	{
		public DbSet<Ciudad> Ciudades { get; set; }
		public DbSet<Domicilio> Domicilios { get; set; }
		public DbSet<EstadoPedido> EstadosPedido { get; set; }
		public DbSet<Tarjeta> Tarjetas { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<FormaPago> FormasPago { get; set; }
	}
}
