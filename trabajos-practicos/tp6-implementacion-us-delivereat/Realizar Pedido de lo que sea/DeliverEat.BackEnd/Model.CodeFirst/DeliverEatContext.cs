namespace DeliverEat.BackEnd.Model.CodeFirst
{
	using System;
    using System.Collections.Generic;
    using System.Data.Entity;
	using System.Linq;
    using SQLite.CodeFirst;

    public class DeliverEatContext : DbContext
	{
		// El contexto se ha configurado para usar una cadena de conexión 'DeliverEat' del archivo 
		// de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
		// esta cadena de conexión tiene como destino la base de datos 'DeliverEat.BackEnd.Model.DeliverEat' de la instancia LocalDb. 
		// 
		// Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
		// modifique la cadena de conexión 'DeliverEat'  en el archivo de configuración de la aplicación.
		public DeliverEatContext()
			: base("name=DeliverEat")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		// Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
		// sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
		public DbSet<Ciudad> Ciudades { get; set; }
		public DbSet<Domicilio> Domicilios { get; set; }
		public DbSet<EstadoPedido> EstadosPedido { get; set; }
		public DbSet<FormaPago> FormasPago { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<Tarjeta> Tarjetas { get; set; }

		// Reemplazamos el metodo cuando cambia el modelo para generar una base de datos SQLite mediante CodeFirst.SQLite

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var sqliteConnectionInitializer = new InicializarBD(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}

		// Acá inicializamos la base de datos agregando los datos que nos haga falta
		// al SQL nuevo.
		public class InicializarBD : SqliteDropCreateDatabaseWhenModelChanges<DeliverEatContext>
		{
			public InicializarBD(DbModelBuilder modelBuilder)
				: base(modelBuilder) { }

			protected override void Seed(DeliverEatContext context)
			{
				context.Database.ExecuteSqlCommand("PRAGMA foreign_keys=on;");

				context.Set<Ciudad>().Add(new Ciudad { Nombre = "Cordoba" });
				context.Set<Ciudad>().Add(new Ciudad { Nombre = "Villa María" });
				context.Set<Ciudad>().Add(new Ciudad { Nombre = "Arguello" });
				context.Set<Ciudad>().Add(new Ciudad { Nombre = "Villa Carlos Paz" });
				context.Set<Ciudad>().Add(new Ciudad { Nombre = "Coronel Olmedo" });

				context.Set<FormaPago>().Add(new FormaPago { Nombre = "EFE", Descripcion = "Efectivo" });
				context.Set<FormaPago>().Add(new FormaPago { Nombre = "VISA", Descripcion = "Tarjeta de Credito Visa" });

				context.Set<EstadoPedido>().Add(new EstadoPedido { Nombre = "N", Descripcion = "Nuevo" });
				context.Set<EstadoPedido>().Add(new EstadoPedido { Nombre = "C", Descripcion = "A entregar" });
				context.Set<EstadoPedido>().Add(new EstadoPedido { Nombre = "E", Descripcion = "Entregado" });
			}
		}

	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}