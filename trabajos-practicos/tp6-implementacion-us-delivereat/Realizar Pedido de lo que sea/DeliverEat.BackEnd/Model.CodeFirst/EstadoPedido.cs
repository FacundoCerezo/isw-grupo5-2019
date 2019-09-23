﻿using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model.CodeFirst
{
	[Table("EstadosPedido")]
	public class EstadoPedido
	{
		[Autoincrement]
		public int Id { get; set; }
		public String Nombre { get; set; }
		public String Descripcion { get; set; }

	}
}
