using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeeklyTalks.Models;

namespace WeeklyTalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitsController : ControllerBase
    {
        private readonly db_weeklytalksContext _context;

        public BusinessUnitsController(db_weeklytalksContext context)
        {
            _context = context;
        }

        // GET: api/BusinessUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessUnits>>> GetBusinessUnits()
        {
            return await _context.BusinessUnits.ToListAsync();
        }

        // GET: api/BusinessUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessUnits>> GetBusinessUnits(long id)
        {
            var businessUnits = await _context.BusinessUnits.FindAsync(id);

            if (businessUnits == null)
            {
                return NotFound();
            }

            return businessUnits;
        }

        // PUT: api/BusinessUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessUnits(long id, BusinessUnits businessUnits)
        {
            if (id != businessUnits.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessUnits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessUnitsExists(id))
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

        // POST: api/BusinessUnits
        [HttpPost]
        public async Task<ActionResult<BusinessUnits>> PostBusinessUnits(BusinessUnits businessUnits)
        {
            _context.BusinessUnits.Add(businessUnits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessUnits", new { id = businessUnits.Id }, businessUnits);
        }

        // DELETE: api/BusinessUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessUnits>> DeleteBusinessUnits(long id)
        {
            var businessUnits = await _context.BusinessUnits.FindAsync(id);
            if (businessUnits == null)
            {
                return NotFound();
            }

            _context.BusinessUnits.Remove(businessUnits);
            await _context.SaveChangesAsync();

            return businessUnits;
        }

        private bool BusinessUnitsExists(long id)
        {
            return _context.BusinessUnits.Any(e => e.Id == id);
        }
    }
}
