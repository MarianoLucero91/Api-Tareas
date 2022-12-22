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
            _tareasService.AddTarea(tarea);

            return Ok("La tarea se creó con éxito");
        }

        [HttpDelete]

        public ActionResult<TareasDto> DeleteTarea([FromBody] Tareas tarea)
        {
            _tareasService.DeleteTarea(tarea);

            return Ok("Tarea borrada exitosamente");
        }

        [HttpPut]

        public ActionResult<TareasDto> UpdateTarea([FromBody] Tareas tarea)
        {
            _tareasService.UpdateTarea(tarea);

            return Ok("La tarea se ha actualizado");
        }

        [HttpGet]

        public ActionResult<IEnumerable<TareasDto>> GetAll()
        {
            var tasks = _tareasService.GetAll();

            if (tasks == null)
            {
                throw new Exception("Ninguna tarea fue registrada");
            }
            return Ok(tasks);
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
