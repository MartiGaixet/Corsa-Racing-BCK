using CorsaRacing.Models;

namespace CorsaRacing.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        Task UpdateUser(User user);
        void DeleteUser(int id);
    }
}
