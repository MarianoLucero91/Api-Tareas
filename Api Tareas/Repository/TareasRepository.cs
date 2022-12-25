using Api_Tareas.Data;
using Api_Tareas.Models;
using Api_Tareas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Tareas.Repository
{
    public class TareasRepository : ITareasRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TareasRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tareas AddTarea(Tareas tarea)
        {
            _dbContext.Tareas.Add(tarea);
            _dbContext.SaveChanges();
            return tarea;
        }

        public bool DeleteTarea(Tareas tarea)
        {
            _dbContext.Tareas.Remove(tarea);
            _dbContext.SaveChanges();
            return true;
        }

        public Tareas UpdateTarea(Tareas tarea)
        {
            _dbContext.Update(tarea);
            _dbContext.SaveChanges();
            return tarea;
        }

        public Tareas GetById (int id)
        {
            var task = _dbContext.Tareas.Where(t => t.Id == id).FirstOrDefault();
            _dbContext.SaveChanges();
            return task;
        }

        public IEnumerable<Tareas> GetActive()
        {
            return _dbContext.Tareas.Where(t => t.Realizada == false).ToList();
            
        }

        public IEnumerable<Tareas> GetAll()
        {
            return _dbContext.Tareas.ToList();
        }
    }
}
