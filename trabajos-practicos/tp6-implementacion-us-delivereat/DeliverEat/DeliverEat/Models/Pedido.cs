using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliverEat.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Detalle { get; set; }

       
        public decimal Precio { get; set; }

        [Display(Name = "Domicilio entrega")]
        public Domicilio DomicilioEntrega { get; set; }

        [Display(Name = "Domicilio recogida")]
        public Domicilio DomicilioRecogida { get; set; }

        [Display(Name = "Fecha de entrega")]
        [DataType(DataType.Date)]
        public DateTime FechaDeEntrega { get; set; }

        [Display(Name = "Hora de entrega")]
        [DataType(DataType.Time)]
        public DateTime HoraDeEntrega { get; set; }

        public string Telefono { get; set; }

        public Pago Pago { get; set; }
    }
}