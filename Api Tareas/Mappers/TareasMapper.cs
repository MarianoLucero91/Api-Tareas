using Api_Tareas.Dto;
using Api_Tareas.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiTareas.Mappers
{
    public class TareasMapper
    {
        public TareasDto MapToDto(Tareas task)
        {
            if (task == null) return null;

            return new TareasDto()
            {
                Id = task.Id,
                Texto = task.Texto,
                FechaDeCreacion = task.FechaDeCreacion,
                Realizada = task.Realizada,
            };
        }

        public List<TareasDto> MapManyToDto(List<Tareas> task)
        {
            if (task == null) return null;

            return task.Select(t => new TareasDto
            {
                Id = t.Id,
                Texto = t.Texto,
                FechaDeCreacion = t.FechaDeCreacion,
                Realizada = t.Realizada,
            }).ToList();
        }
    }
    
}





