using System.Collections.Generic;
using System.Threading.Tasks;
using CorsaRacing.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsaRacing.Repositories
{
    public class ParticipationRaceRepository : IParticipationRaceRepository
    {
        private readonly Context _context;

        public ParticipationRaceRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParticipationRace>> GetAllAsync()
        {
            return await _context.ParticipationRace.Include(pr => pr.Driver).Include(pr => pr.Race).ToListAsync();
        }

        public async Task<ParticipationRace> GetByIdAsync(int id)
        {
            return await _context.ParticipationRace.FindAsync(id);
        }

        public async Task AddAsync(ParticipationRace participationRace)
        {
            _context.ParticipationRace.Add(participationRace);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var participation = await _context.ParticipationRace.FindAsync(id);
            if (participation != null)
            {
                _context.ParticipationRace.Remove(participation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int userId, int raceId)
        {
            return await _context.ParticipationRace.AnyAsync(pr => pr.UserId == userId && pr.RaceId == raceId);
        }
    }
}
