using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayBooksController : ControllerBase
    {
        private readonly SchoolAppContext _context;

        public DisplayBooksController(SchoolAppContext context)
        {
            _context = context;
        }

        // GET: api/DisplayBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayBook>>> GetDisplayBook()
        {
            return await _context.DisplayBook.ToListAsync();
        }

        // GET: api/DisplayBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayBook>> GetDisplayBook(int id)
        {
            var displayBook = await _context.DisplayBook.FindAsync(id);

            if (displayBook == null)
            {
                return NotFound();
            }

            return displayBook;
        }

        // PUT: api/DisplayBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisplayBook(int id, DisplayBook displayBook)
        {
            if (id != displayBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(displayBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisplayBookExists(id))
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

        // POST: api/DisplayBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisplayBook>> PostDisplayBook(DisplayBook displayBook)
        {
            _context.DisplayBook.Add(displayBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisplayBook", new { id = displayBook.Id }, displayBook);
        }

        // DELETE: api/DisplayBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisplayBook(int id)
        {
            var displayBook = await _context.DisplayBook.FindAsync(id);
            if (displayBook == null)
            {
                return NotFound();
            }

            _context.DisplayBook.Remove(displayBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisplayBookExists(int id)
        {
            return _context.DisplayBook.Any(e => e.Id == id);
        }
    }
}
