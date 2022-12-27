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
    public class EquipmentController : ControllerBase
    {
        private readonly ElectronicRepairDbContext _context;

        public EquipmentController(ElectronicRepairDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipments()
        {
          if (_context.Equipments == null)
          {
              return NotFound();
          }
            return await _context.Equipments.ToListAsync();
        }

        // GET: api/Equipment
        [HttpGet("getEquipByAreaId/{areaId}")]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipByAreaId(int areaId)
        {
            if (_context.Equipments == null)
            {
                return NotFound();
            }
            return await _context.Equipments.Where(e => e.AreaId == areaId).ToListAsync();
        }

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
          if (_context.Equipments == null)
          {
              return NotFound();
          }
            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // PUT: api/Equipment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentId)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(string equipName, int areaId)
        {
            Equipment newEquip = new Equipment()
            {
                EquipmentName = equipName,
                Area = _context.Areas.FirstOrDefault(a => a.AreaId == areaId),
                AreaId = areaId
            };
          if (_context.Equipments == null)
          {
              return Problem("Entity set 'ElectronicRepairDbContext.Equipments'  is null.");
          }
           
            _context.Equipments.Add(newEquip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipment", new { id = newEquip.EquipmentId }, newEquip);
        }

        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            if (_context.Equipments == null)
            {
                return NotFound();
            }
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentExists(int id)
        {
            return (_context.Equipments?.Any(e => e.EquipmentId == id)).GetValueOrDefault();
        }
    }
}
