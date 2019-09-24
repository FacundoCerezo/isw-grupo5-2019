using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model.CodeFirst
{
	[Table("Tarjetas")]
	public class Tarjeta
	{
		[Autoincrement]
		public int Id { get; set; }
		public String Numero { get; set; }
		public String NombreTitular { get; set; }
		[MaxLength(4)]
		public String Anio { get; set; }
		[MaxLength(2)]
		public String Mes { get; set; }
		[MaxLength(3)]
		public String CVC { get; set; }
	}
}
