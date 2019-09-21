using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliverEat.Models
{
    public class Tarjeta
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        public Boolean Descripcion { get; set; }

        [Display(Name = "Número")]
        public String Numero { get; set; }

        [Display(Name = "Nombre del titular")]
        public String Nombre { get; set; }

        [Display(Name = "Apellido del titular")]
        public String Apellido { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        public String Vencimiento { get; set; }

        [Display(Name = "CVV")]
        public String CvC { get; set; }
    }
}