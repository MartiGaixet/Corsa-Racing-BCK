using CorsaRacing.Models;
using CorsaRacing.Repositories;

namespace CorsaRacing.Services
{
    public class RaceService : IRaceService
    {

        private readonly IRacesRepository _raceRepository;

        public RaceService(IRacesRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }


        public void AddRace(Race race)
        {
            _raceRepository.AddRace(race);
        }

        public void DeleteRace(int id)
        {
            _raceRepository.DeleteRace(id);
        }

        public IEnumerable<Race> GetAllRaces()
        {
            return _raceRepository.GetAllRaces();
        }

        public Race GetRaceById(int id)
        {
            return _raceRepository.GetRaceById(id);
        }

        public void UpdateRace(Race race)
        {
            _raceRepository.UpdateRace(race);
        }

        public async Task<List<Race>> GetRacesByChampionshipId(int championshipId)
        {
            return await _raceRepository.GetRacesByChampionshipId(championshipId);
        }
    }
}
