using Api_Tareas.Dto;
using Api_Tareas.Models;
using Api_Tareas.Repository.IRepository;
using Api_Tareas.Services.IServices;
using ApiTareas.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Tareas.Services
{
    public class TareasService : ITareasService
    {
        private readonly ITareasRepository _tareasRepository;


        public TareasService(ITareasRepository tareasRepository)
        {
            _tareasRepository = tareasRepository;
        }

        public IEnumerable<TareasDto> GetActive()
        {
            var task = _tareasRepository.GetActive().ToList();

            if (task == null) throw new Exception("Todas las tareas fueron realizadas");
            

            TareasMapper tareasMapper = new TareasMapper();
            return tareasMapper.MapManyToDto(task);
        }

        public IEnumerable<TareasDto> GetAll()
        {
            var task = _tareasRepository.GetAll().ToList();

            if (task == null) throw new Exception("No se encontraron tareas");
            
            TareasMapper tareasMapper = new TareasMapper();
            return tareasMapper.MapManyToDto(task);
        }

        public TareasDto GetById(int id)
        {
            var task = _tareasRepository.GetById(id);

            if (task == null) throw new Exception("No se encontro ninguna tarea con este ID");
            TareasMapper tareasMapper = new TareasMapper();
            return tareasMapper.MapToDto(task);
        }

        public TareasDto AddTarea(Tareas tarea)
        {
            if (tarea == null) throw new Exception("Debe ingresar una tarea a realizar");

            tarea.FechaDeCreacion = DateTime.Now;
            _tareasRepository.AddTarea(tarea);

            TareasMapper tareasMapper = new TareasMapper();
            return tareasMapper.MapToDto(tarea);
        }

        public bool DeleteTarea(int id)
        {
            if (id == 0) throw new Exception("Debe especificar la tarea a eliminar");
            var task = _tareasRepository.GetById(id);

            if (task == null) throw new Exception("No se encontro la tarea a eliminar");
            _tareasRepository.DeleteTarea(task);
            
            return true;
        }

        public Tareas UpdateTarea(Tareas request)
        {
            var tarea = _tareasRepository.GetById(request.Id);
            tarea.Realizada = request.Realizada;
            tarea.Texto = request.Texto;

            if (tarea == null) throw new Exception("No se encontró ninguna tarea con el ID indicado");

            return _tareasRepository.UpdateTarea(tarea);
        }
    }
}
