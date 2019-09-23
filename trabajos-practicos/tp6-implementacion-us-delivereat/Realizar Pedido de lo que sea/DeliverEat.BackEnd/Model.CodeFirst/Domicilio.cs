using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliverEat.BackEnd.Model.CodeFirst
{
	[Table("Domicilios")]
	public class Domicilio
	{
		[Key]
		public int Id { get; set; }
		public string Calle { get; set; }
		public short Numero { get; set; }
		public string Descripcion { get; set; }
		[Required]
		public int CiudadId { get; set; }
		[ForeignKey("CiudadId")]
		public virtual Ciudad Ciudad { get; set; }
	}
}