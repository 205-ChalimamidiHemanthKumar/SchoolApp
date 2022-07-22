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
    public class AddBooksController : ControllerBase
    {
        private readonly SchoolAppContext _context;

        public AddBooksController(SchoolAppContext context)
        {
            _context = context;
        }

        // GET: api/AddBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddBook>>> GetAddBook()
        {
            return await _context.AddBook.ToListAsync();
        }

        // GET: api/AddBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddBook>> GetAddBook(int id)
        {
            var addBook = await _context.AddBook.FindAsync(id);

            if (addBook == null)
            {
                return NotFound();
            }

            return addBook;
        }

        // PUT: api/AddBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddBook(int id, AddBook addBook)
        {
            if (id != addBook.BookId)
            {
                return BadRequest();
            }

            _context.Entry(addBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddBookExists(id))
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

        // POST: api/AddBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddBook>> PostAddBook(AddBook addBook)
        {
            _context.AddBook.Add(addBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddBook", new { id = addBook.BookId }, addBook);
        }

        // DELETE: api/AddBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddBook(int id)
        {
            var addBook = await _context.AddBook.FindAsync(id);
            if (addBook == null)
            {
                return NotFound();
            }

            _context.AddBook.Remove(addBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddBookExists(int id)
        {
            return _context.AddBook.Any(e => e.BookId == id);
        }
    }
}
