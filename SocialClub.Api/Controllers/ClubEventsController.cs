using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialClub.Api.Models;

namespace SocialClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClubEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClubEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubEvent>>> GetClubEvent()
        {
          if (_context.ClubEvent == null)
          {
              return NotFound();
          }
            return await _context.ClubEvent.ToListAsync();
        }

        // GET: api/ClubEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClubEvent>> GetClubEvent(int id)
        {
          if (_context.ClubEvent == null)
          {
              return NotFound();
          }
            var clubEvent = await _context.ClubEvent.FindAsync(id);

            if (clubEvent == null)
            {
                return NotFound();
            }

            return clubEvent;
        }

        // PUT: api/ClubEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClubEvent(int id, ClubEvent clubEvent)
        {
            if (id != clubEvent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(clubEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubEventExists(id))
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

        // POST: api/ClubEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClubEvent>> PostClubEvent(ClubEvent clubEvent)
        {
          if (_context.ClubEvent == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ClubEvent'  is null.");
          }
            _context.ClubEvent.Add(clubEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClubEvent", new { id = clubEvent.EventId }, clubEvent);
        }

        // DELETE: api/ClubEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClubEvent(int id)
        {
            if (_context.ClubEvent == null)
            {
                return NotFound();
            }
            var clubEvent = await _context.ClubEvent.FindAsync(id);
            if (clubEvent == null)
            {
                return NotFound();
            }

            _context.ClubEvent.Remove(clubEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClubEventExists(int id)
        {
            return (_context.ClubEvent?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
