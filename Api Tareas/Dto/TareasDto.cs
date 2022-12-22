using System;

namespace Api_Tareas.Dto
{
    public class TareasDto
    {
        public int Id { get; set; }       
        public string Texto { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public bool Realizada { get; set; }
    }
}
