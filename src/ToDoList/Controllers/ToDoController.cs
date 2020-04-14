using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Controllers
{
        [Route("api/[controller]")]
        //[ApiController]
        public class ToDoController : ControllerBase
        {
            private readonly ToDoListContext _context;

            public ToDoController(ToDoListContext context)
            {
                _context = context;
            }

            // GET: api/Movies
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
            {
                return await _context.ToDo.ToListAsync();
            }

            // GET: api/ToDo/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ToDo>> GetToDo(int id)
            {
                var todo = await _context.ToDo.First(id);

                if (todo == null)
                {
                    return NotFound();
                }

                return todo;
            }

            // PUT: api/ToDo/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutToDo(int id, T todo)
            {
                if (id != todo.Id)
                {
                    return BadRequest();
                }

                _context.Entry(todo).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/ToDo
            [HttpPost]
            public async Task<ActionResult<T>> PostToDo(T todo)
            {
                _context.ToDo.Add(todo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetToDo", new { id = todo.Id }, todo);
            }

            // DELETE: api/ToDo/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<ToDo>> DeleteToDo(int id)
            {
                var todo = await _context.ToDo.MinAsync(id);
                if (todo == null)
                {
                    return NotFound();
                }

                _context.ToDo.Remove(todo);
                await _context.SaveChangesAsync();

                return todo;
            }

            private bool ToDoExists(int id)
            {
                return _context.ToDo.Any(e => e.Id == id);
            }
        }    
}
