using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;
using CorsaRacing.Models;
using CorsaRacing.Repositories;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace CorsaRacing.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _userRepository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            
            var existingUser = _userRepository.GetUserById(user.Id);
            if (existingUser != null && user.Password != existingUser.Password)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            _userRepository.UpdateUser(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.Email == email);
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = GetUserByEmail(email);

            
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }

    }
}
