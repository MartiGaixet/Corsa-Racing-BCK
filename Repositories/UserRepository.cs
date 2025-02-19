using CorsaRacing.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsaRacing.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Drivers.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Drivers.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Drivers.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Drivers.Find(id);
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
