using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3F3R.Models
{
    public class Zona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
        public int CP { get; set; }       
        public string Localidad { get; set; }
        public string Calle { get; set; }    
        public int Altura { get; set; }    
    
        public Puesto PuestoCercano { get; set; }
    }
}