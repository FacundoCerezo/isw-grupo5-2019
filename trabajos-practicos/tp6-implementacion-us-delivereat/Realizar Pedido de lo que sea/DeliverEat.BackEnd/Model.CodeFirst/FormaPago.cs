using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model.CodeFirst
{
	[Table("FormasPago")]
	public class FormaPago
	{
		[Autoincrement]
		public int Id { get; set; }
		[Unique]
		public String Nombre { get; set; }
		public String Descripcion { get; set; }
	}
}
