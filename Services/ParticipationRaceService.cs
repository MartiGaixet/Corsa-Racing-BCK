using System.Collections.Generic;
using System.Threading.Tasks;
using CorsaRacing.Models;
using CorsaRacing.Repositories;

namespace CorsaRacing.Services
{
    public class ParticipationRaceService : IParticipationRaceService
    {
        private readonly IParticipationRaceRepository _participationRaceRepository;

        public ParticipationRaceService(IParticipationRaceRepository participationRaceRepository)
        {
            _participationRaceRepository = participationRaceRepository;
        }

        public async Task<IEnumerable<ParticipationRace>> GetAllAsync()
        {
            return await _participationRaceRepository.GetAllAsync();
        }

        public async Task<ParticipationRace> GetByIdAsync(int id)
        {
            return await _participationRaceRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddParticipationAsync(int userId, int raceId)
        {

            var participation = new ParticipationRace { UserId = userId, RaceId = raceId };
            await _participationRaceRepository.AddAsync(participation);
            return true;
        }

        public async Task DeleteParticipationAsync(int id)
        {
            await _participationRaceRepository.DeleteAsync(id);
        }
    }
}
