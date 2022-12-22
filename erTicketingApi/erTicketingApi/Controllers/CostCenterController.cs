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
    public class CostCenterController : ControllerBase
    {
        private readonly ElectronicRepairDbContext _context;

        public CostCenterController(ElectronicRepairDbContext context)
        {
            _context = context;
        }

        // GET: api/CostCenter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostCenter>>> GetCostCenters()
        {
          if (_context.CostCenters == null)
          {
              return NotFound();
          }
            return await _context.CostCenters.ToListAsync();
        }

        // GET: api/CostCenter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CostCenter>> GetCostCenter(int id)
        {
          if (_context.CostCenters == null)
          {
              return NotFound();
          }
            var costCenter = await _context.CostCenters.FindAsync(id);

            if (costCenter == null)
            {
                return NotFound();
            }

            return costCenter;
        }

        // PUT: api/CostCenter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostCenter(int id, CostCenter costCenter)
        {
            if (id != costCenter.CostCenterId)
            {
                return BadRequest();
            }

            _context.Entry(costCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostCenterExists(id))
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

        // POST: api/CostCenter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CostCenter>> PostCostCenter(CostCenter costCenter)
        {
          if (_context.CostCenters == null)
          {
              return Problem("Entity set 'ElectronicRepairDbContext.CostCenters'  is null.");
          }
            _context.CostCenters.Add(costCenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostCenter", new { id = costCenter.CostCenterId }, costCenter);
        }

        // DELETE: api/CostCenter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostCenter(int id)
        {
            if (_context.CostCenters == null)
            {
                return NotFound();
            }
            var costCenter = await _context.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return NotFound();
            }

            _context.CostCenters.Remove(costCenter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CostCenterExists(int id)
        {
            return (_context.CostCenters?.Any(e => e.CostCenterId == id)).GetValueOrDefault();
        }
    }
}
