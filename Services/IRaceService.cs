using CorsaRacing.Models;

namespace CorsaRacing.Services
{
    public interface IRaceService
    {
        IEnumerable<Race> GetAllRaces();
        Race GetRaceById(int id);
        void AddRace(Race race);
        void UpdateRace(Race race);
        void DeleteRace(int id);
        Task<List<Race>> GetRacesByChampionshipId(int championshipId);

    }
}
