using Api_Tareas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Tareas.Repository.IRepository
{
    public interface ITareasRepository
    {
        Tareas AddTarea(Tareas tarea);
        Tareas UpdateTarea(Tareas tarea);
        Tareas DeleteTarea(Tareas tarea);
        Tareas GetById(int id);
        IEnumerable<Tareas> GetActive();
        IEnumerable<Tareas> GetAll();
    }
}
