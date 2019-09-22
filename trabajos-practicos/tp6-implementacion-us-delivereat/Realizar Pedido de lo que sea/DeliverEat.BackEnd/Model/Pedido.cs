using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverEat.BackEnd.Model
{
	public class Pedido
	{
		public int Id { get; set; }
		public int CodPedido { get; set; }
		public Domicilio DomicilioOrigen { get; set; }
		public Domicilio DomicilioEntrega { get; set; }
		public double Monto { get; set; }
		public FormaPago FormaPago {get; set;}
		public Tarjeta Tarjeta { get; set; }
		public DateTime FechaHoraEntrega { get; set; }
		public EstadoPedido Estado { get; set; }
	}
}
