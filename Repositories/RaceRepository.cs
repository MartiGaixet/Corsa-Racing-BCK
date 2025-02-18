using CorsaRacing.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsaRacing.Repositories
{
    public class RaceRepository : IRacesRepository
    {

        private readonly Context _context;

        public RaceRepository(Context context)
        {
            _context = context;
        }

        public void AddRace(Race race)
        {
            _context.Races.Add(race);
            _context.SaveChanges();
        }

        public void DeleteRace(int id)
        {

            var race = GetRaceById(id);
            if (race != null)
            {
                _context.Races.Remove(race);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Race> GetAllRaces()
        {
            return _context.Races
                .Include(r => r.ParticipationRace)
                .ToList();
        }

        public Race GetRaceById(int id)
        {
            return _context.Races.Find(id);
        }

        public void UpdateRace(Race race)
        {
            _context.Races.Update(race);
            _context.SaveChanges();
        }

        public async Task<List<Race>> GetRacesByChampionshipId(int championshipId)
        {
            return await _context.Races
                .Where(r => r.ChampionshipId == championshipId)
                .OrderBy(r => r.Date)
                .Include(r => r.ParticipationRace)// Ordenar por fecha ascendente
                .ToListAsync();
        }
    }
}
