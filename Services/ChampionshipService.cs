using CorsaRacing.Models;
using CorsaRacing.Repositories;

namespace CorsaRacing.Services
{
    public class ChampionshipService : IChampionshipService
    { 

        private readonly IChampionshipRepository _championshipRepository;

        public ChampionshipService(IChampionshipRepository championsRepository)
        {
            _championshipRepository = championsRepository;
        }

    
        public void AddChampionship(Championship championship)
        {
            _championshipRepository.AddChampionship(championship);
        }

        public void DeleteChampionship(int id)
        {
            _championshipRepository.DeleteChampionship(id);
        }

        public async Task<IEnumerable<Championship>> GetAllChampionships()
        {
            return await _championshipRepository.GetAllChampionships();
        }

        public Championship GetChampionshipById(int id)
        {
            return _championshipRepository.GetChampionshipById(id);
        }

        public void UpdateChampionship(Championship championship)
        {
            _championshipRepository.UpdateChampionship(championship);
        }
    }
}
