using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model
{
	public class Tarjeta
	{
		public int Id { get; set; }
		public String Numero { get; set; }
		public String NombreTitular { get; set; }
		public int Anio { get; set; }
		public byte Mes { get; set; }
	}
}
