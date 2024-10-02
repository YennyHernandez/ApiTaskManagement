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

        [HttpGet(Name = "GetTasks")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTasks()
        {
            return await _contex.Tareas.ToListAsync();
        }

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
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTask(Tarea tarea)
        {
            _contex.Tareas.Add(tarea);
            await _contex.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _contex.Entry(tarea).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
            return Ok();
        }

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