using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly DataContex _context;

        public StateController(DataContex context)
        {
            _context = context;
        }

        //EndPoint para obtener lista de estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        //EndPoint para crear estado
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            if (state == null || state.StateName == "")
            {
                return BadRequest("El estado no puede ser nulo y el nombre del estado no puede estar vacío.");
            }
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStates), new { id = state.Id }, state);
        }

        //EndPoint para actualizar estado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //EndPoint para eliminar un estado existente    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
