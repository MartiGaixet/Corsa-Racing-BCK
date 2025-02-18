using System.Collections.Generic;
using System.Threading.Tasks;
using CorsaRacing.Models;

namespace CorsaRacing.Repositories
{
    public interface IParticipationRaceRepository
    {
        Task<IEnumerable<ParticipationRace>> GetAllAsync();
        Task<ParticipationRace> GetByIdAsync(int id);
        Task AddAsync(ParticipationRace participationRace);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int userId, int raceId);
    }
}

