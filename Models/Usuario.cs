using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3F3R.Models
{
    public class Usuario
    {
        [Key]
        public string Mail { get; set; }
        [Required]
        public string Nombre { get; set; }
            
    }
}