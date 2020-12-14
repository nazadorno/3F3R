using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3F3R.Models
{
    public class Puesto
    {
        [Key]
        public int CP { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        public string Plaza { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Horarios { get; set; }
    }
}