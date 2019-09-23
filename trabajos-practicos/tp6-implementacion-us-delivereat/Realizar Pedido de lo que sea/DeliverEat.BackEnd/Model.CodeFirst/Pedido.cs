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
	[Table("Pedidos")]
	public class Pedido
	{
		[Key]
		[Autoincrement]
		public int Id { get; set; }
		[Required]
		public double Monto { get; set; }
		public int DomicilioOrigenId { get; set; }
		public int DomicilioDestinoId { get; set; }
		[Required]
		public int EstadoPedidoId { get; set; }
		[Required]
		public int FormaPagoId { get; set; }
		public int TarjetaId { get; set; }
		[Required]
		[ForeignKey("DomicilioOrigenId")]
		public virtual Domicilio DomicilioOrigen { get; set; }
		[Required]
		[ForeignKey("DomicilioDestinoId")]
		public virtual Domicilio DomicilioDestino { get; set; }
		[ForeignKey("EstadoPedidoId")]
		public virtual EstadoPedido EstadoPedido { get; set; }
		[ForeignKey("FormaPagoId")]
		public virtual FormaPago FormaPago { get; set; }
		[Required]
		[ForeignKey("TarjetaId")]
		public virtual Tarjeta Tarjeta { get; set; }
		[Required]
		public String Descripcion { get; set; }
		public String Imagen { get; set; }
		public DateTime FechaEntrega { get; set; }
	}
}
