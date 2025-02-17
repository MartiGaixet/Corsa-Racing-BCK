using CorsaRacing.Models;

namespace CorsaRacing.Repositories
{
    public interface IRacesRepository
    {
        IEnumerable<Race> GetAllRaces();
        Race GetRaceById(int id);
        void AddRace(Race race);
        void UpdateRace(Race race);
        void DeleteRace(int id);
        Task<List<Race>> GetRacesByChampionshipId(int championshipId);


    }
}
