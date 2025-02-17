using CorsaRacing.Models;

namespace CorsaRacing.Services
{
    public interface IChampionshipService
    {
        Task<IEnumerable<Championship>> GetAllChampionships();
        Championship GetChampionshipById(int id);
        void AddChampionship(Championship championship);
        void UpdateChampionship(Championship championship);
        void DeleteChampionship(int id);
    }
}
