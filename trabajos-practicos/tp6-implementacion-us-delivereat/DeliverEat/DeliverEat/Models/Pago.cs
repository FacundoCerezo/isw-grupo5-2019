using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliverEat.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        public Boolean Efectivo { get; set; }
        public string Monto { get; set; }
        public Tarjeta Tarjeta { get; set; }
    }
}