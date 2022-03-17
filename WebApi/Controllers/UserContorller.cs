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
        private static List<UserInfo> _users = new List<UserInfo>();


        public UserContorller(Storage storage)
        {
            _storage = storage;
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] CreateUserRequest req )
        {
            var user = new UserInfo()
            {
                Id = _users.Count + 1,
                Email = req.Email,
                UserName = req.UserName
            };

            _storage.Users.Add(user);
            _users.Add(user);
            return Ok(user);
        }

        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById([FromBody] int id)
        {
            var result = _users.SingleOrDefault(p => p.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }
    }
}
