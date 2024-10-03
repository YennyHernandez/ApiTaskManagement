using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly DataContex _contex;
        public TaskController(ILogger<TaskController> logger, DataContex contex)
        {
            _logger = logger;
            _contex = contex;
        }

        // EndPoint para obtener lista de tareas
        [HttpGet(Name = "GetTasks")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTasks()
        {
            return await _contex.Tareas.ToListAsync();
        }

        // EndPoint para obtener lista de tareas por ID
        [HttpGet("{id}", Name = "GetTask")]
        public async Task<ActionResult<Tarea>> GetTask(int id)
        {
            var tarea = await _contex.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }
        //EndPoint para obtener lista de estados para relacionar
        [HttpGet("listStates", Name = "GetStates")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _contex.States.ToListAsync();
            return Ok(states);
        }

        // EndPoint para crear tarea
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTask(Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("La tarea no puede ser nula.");
            }

            // Verifica que el estado asociado exista
            var estadoExistente = await _contex.States.FindAsync(tarea.StateId);
            if (estadoExistente == null)
            {
                return BadRequest("El estado especificado no existe.");
            }

            _contex.Tareas.Add(tarea);
            await _contex.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = tarea.Id }, tarea);
        }

        // EndPoint para actualizar tarea existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _contex.Entry(tarea).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
            return Ok(tarea);
        }

        // EndPoint para eliminar tarea existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var tarea = await _contex.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _contex.Tareas.Remove(tarea);
            await _contex.SaveChangesAsync();

            return NoContent();
        }

    }
}