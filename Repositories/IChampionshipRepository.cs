using CorsaRacing.Models;

namespace CorsaRacing.Repositories
{
    public interface IChampionshipRepository
    {
        Task<IEnumerable<Championship>> GetAllChampionships();
        Championship GetChampionshipById(int id);
        void AddChampionship(Championship championship);
        void UpdateChampionship(Championship championship);
        void DeleteChampionship(int id);
    }
}
