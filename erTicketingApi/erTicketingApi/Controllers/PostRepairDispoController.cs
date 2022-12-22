using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using erTicketingApi.Models;

namespace erTicketingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostRepairDispoController : ControllerBase
    {
        private readonly ElectronicRepairDbContext _context;

        public PostRepairDispoController(ElectronicRepairDbContext context)
        {
            _context = context;
        }

        // GET: api/PostRepairDispo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostRepairDispo>>> GetPostRepairDispos()
        {
          if (_context.PostRepairDispos == null)
          {
              return NotFound();
          }
            return await _context.PostRepairDispos.ToListAsync();
        }

        // GET: api/PostRepairDispo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostRepairDispo>> GetPostRepairDispo(int id)
        {
          if (_context.PostRepairDispos == null)
          {
              return NotFound();
          }
            var postRepairDispo = await _context.PostRepairDispos.FindAsync(id);

            if (postRepairDispo == null)
            {
                return NotFound();
            }

            return postRepairDispo;
        }

        // PUT: api/PostRepairDispo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostRepairDispo(int id, PostRepairDispo postRepairDispo)
        {
            if (id != postRepairDispo.PostRepairDispoId)
            {
                return BadRequest();
            }

            _context.Entry(postRepairDispo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostRepairDispoExists(id))
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

        // POST: api/PostRepairDispo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostRepairDispo>> PostPostRepairDispo(PostRepairDispo postRepairDispo)
        {
          if (_context.PostRepairDispos == null)
          {
              return Problem("Entity set 'ElectronicRepairDbContext.PostRepairDispos'  is null.");
          }
            _context.PostRepairDispos.Add(postRepairDispo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostRepairDispo", new { id = postRepairDispo.PostRepairDispoId }, postRepairDispo);
        }

        // DELETE: api/PostRepairDispo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostRepairDispo(int id)
        {
            if (_context.PostRepairDispos == null)
            {
                return NotFound();
            }
            var postRepairDispo = await _context.PostRepairDispos.FindAsync(id);
            if (postRepairDispo == null)
            {
                return NotFound();
            }

            _context.PostRepairDispos.Remove(postRepairDispo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostRepairDispoExists(int id)
        {
            return (_context.PostRepairDispos?.Any(e => e.PostRepairDispoId == id)).GetValueOrDefault();
        }
    }
}
