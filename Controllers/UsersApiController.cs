using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CorsaRacing.Models;
using CorsaRacing.Services;

namespace CorsaRacing.Controllers
{
    [Route("api/UsersApi")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/UsersApi
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET: api/UsersApi/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/UsersApi/signup
        [HttpPost("signup")]
        public IActionResult Signup(User user)
        {
            if (_userService.GetUserByEmail(user.Email) != null)
            {
                return Conflict(new { message = "Email already in use" });
            }

            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { message = "User registered successfully" });
        }

        // POST: api/UsersApi/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var authenticatedUser = _userService.AuthenticateUser(loginRequest.Email, loginRequest.Password);

            if (authenticatedUser == null)
            {
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }

            return Ok(authenticatedUser);
        }

        // PUT: api/UsersApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest("ID mismatch");
            }

            bool updated = await _userService.UpdateUser(id, updatedUser);
            if (!updated)
            {
                return NotFound();
            }

            return Ok(new { message = "User updated successfully" });
        }
        // DELETE: api/UsersApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.GetUserById(id) == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("byEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
            return Ok(user);
        }
    }
}
