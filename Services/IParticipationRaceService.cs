using System.Collections.Generic;
using System.Threading.Tasks;
using CorsaRacing.Models;

namespace CorsaRacing.Services
{
    public interface IParticipationRaceService
    {
        Task<IEnumerable<ParticipationRace>> GetAllAsync();
        Task<ParticipationRace> GetByIdAsync(int id);
        Task<bool> AddParticipationAsync(int userId, int raceId);
        Task DeleteParticipationAsync(int id);
    }
}
