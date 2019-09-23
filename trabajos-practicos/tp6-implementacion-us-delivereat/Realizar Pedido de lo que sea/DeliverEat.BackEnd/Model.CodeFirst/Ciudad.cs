using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model.CodeFirst
{
	[Table("Ciudades")]
	public class Ciudad
	{
		[Key]
		public int Id { get; set; }
		[Unique]
		public String Nombre { get; set; }
		public String Descripcion { get; set; }
	}
}
