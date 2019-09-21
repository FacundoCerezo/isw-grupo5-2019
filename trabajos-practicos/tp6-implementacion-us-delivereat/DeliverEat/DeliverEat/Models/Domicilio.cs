using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliverEat.Models
{
    public class Domicilio
    {
        [Key]
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}