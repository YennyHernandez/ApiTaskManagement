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

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStates), new { id = state.Id }, state);
        }

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
