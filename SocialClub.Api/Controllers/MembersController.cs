using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialClub.Api.Models;

namespace SocialClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        {
          if (_context.Member == null)
          {
              return NotFound(); 
          }
            return await _context.Member.ToListAsync();
        }

        // GET: api/Members/5           
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
          if (_context.Member == null)
          {
              return NotFound();
          }
            var member = await _context.Member.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
          if (_context.Member == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Member'  is null.");
          }
            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.MemberId }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if (_context.Member == null)
            {
                return NotFound();
            }
            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return (_context.Member?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }

                   
        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<Member>>> GetMemberName(string name)
        {
            if (_context.Member == null)
            {
                return NotFound();
            }

            var members = _context.Member.Where(i => i.FirstName.Contains(name) || i.LastName.Contains(name))
                .Select(j => j).ToList();

            if (members == null)
            {
                return NotFound();
            }

            return members;
        }
    }
}
