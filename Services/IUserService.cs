using System.Collections.Generic;
using CorsaRacing.Models;

namespace CorsaRacing.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
        User GetUserByEmail(string email);
        User AuthenticateUser(string email, string password);
    }
}
