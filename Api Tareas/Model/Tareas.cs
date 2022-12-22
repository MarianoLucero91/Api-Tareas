using System;
using System.ComponentModel.DataAnnotations;

namespace Api_Tareas.Models
{
    public class Tareas
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Texto { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public bool Realizada { get; set; }
    }
}
