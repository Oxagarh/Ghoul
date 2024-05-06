using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ghoul.Models;

namespace Ghoul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DwellersController : ControllerBase
    {
        private readonly WastelandContext _context;

        public DwellersController(WastelandContext context)
        {
            _context = context;
        }

        // GET: api/Dwellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dweller>>> GetDwellers()
        {
            return await _context.Dwellers.ToListAsync();
        }

        // GET: api/Dwellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dweller>> GetDweller(int id)
        {
            var dweller = await _context.Dwellers.FindAsync(id);

            if (dweller == null)
            {
                return NotFound();
            }

            return dweller;
        }

        // PUT: api/Dwellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDweller(int id, Dweller dweller)
        {
            if (id != dweller.Id)
            {
                return BadRequest();
            }

            _context.Entry(dweller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DwellerExists(id))
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

        // POST: api/Dwellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dweller>> PostDweller(Dweller dweller)
        {
            _context.Dwellers.Add(dweller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDweller", new { id = dweller.Id }, dweller);
        }

        // DELETE: api/Dwellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDweller(int id)
        {
            var dweller = await _context.Dwellers.FindAsync(id);
            if (dweller == null)
            {
                return NotFound();
            }

            _context.Dwellers.Remove(dweller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DwellerExists(int id)
        {
            return _context.Dwellers.Any(e => e.Id == id);
        }
    }
}
