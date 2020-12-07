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
        public int CP { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }        
        
        public Puesto Puesto { get; set; }
    }
}