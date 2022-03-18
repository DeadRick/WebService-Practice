using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class UserContorller : Controller
    {
        private Storage _storage;

        public UserContorller(Storage storage)
        {
            _storage = storage;
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] CreateUserRequest req )
        {
            var user = new UserInfo()
            {
                Id = _storage.Users.Count + 1,
                Email = req.Email,
                UserName = req.UserName
            };

            var checkUnique = _storage.Users.SingleOrDefault(p => p.Email == user.Email);

            if (checkUnique != null)
            {
                return BadRequest($"Пользователь с {user.Email} уже существует.");
            }

            _storage.Users.Add(user);
            return Ok(user);
        }

        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById([FromBody] int id)
        {
            var result = _storage.Users.SingleOrDefault(p => p.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_storage.Users);
        }
    }
}
