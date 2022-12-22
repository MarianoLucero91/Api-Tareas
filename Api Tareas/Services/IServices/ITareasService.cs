using Api_Tareas.Dto;
using Api_Tareas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Tareas.Services.IServices
{
    public interface ITareasService
    {
        TareasDto GetById(int id);
        IEnumerable<TareasDto> GetAll();
        IEnumerable<TareasDto> GetActive();
        TareasDto AddTarea(Tareas tarea);
        TareasDto UpdateTarea(Tareas tarea);
        bool DeleteTarea(Tareas tarea);
    }
}
