using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model
{
	public class Ciudad
	{
		public int Id { get; set; }
		public String Nombre { get; set; }
		public String Descripcion { get; set; }
		public virtual List<Domicilio> Domicilios { get; set; }
	}
}
