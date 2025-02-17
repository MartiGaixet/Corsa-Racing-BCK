using CorsaRacing.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsaRacing.Repositories
{
    public class ChampionshipRepository : IChampionshipRepository
    {

        private readonly Context _context;

        public ChampionshipRepository(Context context)
        {
            _context = context;
        }

        public void AddChampionship(Championship championship)
        {
            _context.Championships.Add(championship);
            _context.SaveChanges();
        }

        public void DeleteChampionship(int id)
        {
            var championship = GetChampionshipById(id);
            if (championship != null)
            {
                _context.Championships.Remove(championship);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Championship>> GetAllChampionships()
        {
            return await _context.Championships
                .Include(c => c.Races)
                    .ThenInclude(r => r.ParticipationRace)
                        .ThenInclude(p => p.Driver) // Asegurar que los pilotos están cargados
                .ToListAsync();
        }



        public Championship GetChampionshipById(int id)
        {
            return _context.Championships.Find(id);
        }

        public void UpdateChampionship(Championship championship)
        {
            _context.Championships.Update(championship);
            _context.SaveChanges();
        }
    }
}
