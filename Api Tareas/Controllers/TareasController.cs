using Api_Tareas.Dto;
using Api_Tareas.Models;
using Api_Tareas.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api_Tareas.Controllers
{
    [Route("api/tareas")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareasService _tareasService;

        public TareasController(ITareasService tareasService)
        {
            _tareasService = tareasService;
        }

        [HttpPost]
        public ActionResult<TareasDto> AddTarea([FromBody] Tareas tarea)
        {
            return _tareasService.AddTarea(tarea);
        }

        [HttpDelete]
        public ActionResult<TareasDto> DeleteTarea([FromRoute]int id)
        {
            _tareasService.DeleteTarea(id);

            return Ok("Tarea borrada exitosamente");
        }

        [HttpPut]
        public ActionResult<TareasDto> UpdateTarea([FromBody] Tareas tarea)
        {
            _tareasService.UpdateTarea(tarea);

            return Ok("La tarea se ha actualizado");
        }

        [HttpGet]
        public IEnumerable<TareasDto> GetAll()
        {
            return _tareasService.GetAll();
        }

        [HttpGet("/active")]
        public ActionResult<IEnumerable<TareasDto>> GetActive()
        {
            var tasks = _tareasService.GetActive();

            return Ok(tasks);
        }

        [HttpGet("{tareaId}")]
        public ActionResult<TareasDto> GetById ([FromRoute] int id)
        {
            var taskById = _tareasService.GetById(id);

            return Ok(taskById);
        }
    }
}
