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
        
        TareasMapper tareasMapper = new TareasMapper();


        public TareasService(ITareasRepository tareasRepository)
        {
            tareasRepository = _tareasRepository;
        }

        public IEnumerable<TareasDto> GetActive()
        {            
            var task = _tareasRepository.GetActive().ToList();

            if (task == null)
            {
                throw new Exception("Todas las tareas fueron realizadas");
            }

            var response = tareasMapper.MapManyToDto(task);
            return response;
            
        }

        public IEnumerable<TareasDto> GetAll()
        {
            var task = _tareasRepository.GetAll().ToList();

            if (task == null)
            {
                throw new Exception("No se encontraron tareas");
            }

            var response = tareasMapper.MapManyToDto(task);

            return response;
        }

        public TareasDto GetById(int id)
        {
            var task = _tareasRepository.GetById(id);
            
            if (task == null)
            {
                throw new Exception("No se encontro ninguna tarea con este ID");
            }

            var response = tareasMapper.MapToDto(task);
            return response;
        }
        
        public TareasDto AddTarea(Tareas tarea)
        {
            if (tarea == null)
            {
                throw new Exception("Debe ingresar una tarea a realizar");
            }

            var task = _tareasRepository.AddTarea(tarea);
           
            var response = tareasMapper.MapToDto(task);
            return response;
        }

        public bool DeleteTarea(Tareas tarea)
        {
            if (tarea == null)
            {
                throw new Exception("Por favor ingresar la tarea que desee eliminar");
            }

            _tareasRepository.DeleteTarea(tarea);          
            return true;
        }
       
        public TareasDto UpdateTarea(Tareas tarea)
        {
            var update = _tareasRepository.GetById(tarea.Id);
            if (update == null)
            {
                throw new Exception("No se encontró ninguna tarea con el ID indicado");
            }

            var response = _tareasRepository.UpdateTarea(update);
            var mapped = tareasMapper.MapToDto(response);
            return mapped;
        }
    }
}
