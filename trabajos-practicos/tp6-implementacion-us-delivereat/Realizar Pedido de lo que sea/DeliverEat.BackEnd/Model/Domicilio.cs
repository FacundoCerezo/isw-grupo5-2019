namespace DeliverEat.BackEnd.Model
{
	public class Domicilio
	{
		public int Id { get; set; }
		public string Calle { get; set; }
		public int Numero { get; set; }
		public string Descripcion { get; set; }
		public virtual Ciudad Ciudad { get; set; }
	}
}