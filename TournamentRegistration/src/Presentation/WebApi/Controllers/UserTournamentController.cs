using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserTournamentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserTournamentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTournament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTournament>>> GetUserTournaments()
        {
            return await _context.UserTournaments
                .Include(ut => ut.User)
                .Include(ut => ut.Tournament)
                .ToListAsync();
        }

        // POST: api/UserTournament
        [HttpPost]
        public async Task<ActionResult<UserTournament>> PostUserTournament(UserTournament userTournament)
        {
            _context.UserTournaments.Add(userTournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserTournaments), new { id = userTournament.UserId, tournamentId = userTournament.TournamentId }, userTournament);
        }

        // DELETE: api/UserTournament/5/5
        [HttpDelete("{userId}/{tournamentId}")]
        public async Task<IActionResult> DeleteUserTournament(int userId, int tournamentId)
        {
            var userTournament = await _context.UserTournaments.FindAsync(userId, tournamentId);
            if (userTournament == null)
            {
                return NotFound();
            }

            _context.UserTournaments.Remove(userTournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
