using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SoapService.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tournament>> GetTournaments()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournament> GetTournament(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public async Task AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
        }
    }
}
