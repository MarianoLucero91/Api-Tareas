using Api_Tareas.Models;
using System.Collections.Generic;

namespace Api_Tareas.Repository.IRepository
{
    public interface ITareasRepository
    {
        Tareas AddTarea(Tareas tarea);
        Tareas UpdateTarea(Tareas tarea);
        bool DeleteTarea(Tareas tarea);
        Tareas GetById(int id);
        IEnumerable<Tareas> GetActive();
        IEnumerable<Tareas> GetAll();
    }
}
