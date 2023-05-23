using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DB _db;
        public UserController(DB db)
        {
            this._db = db;
        }
        public async Task<User> Get(long id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return new User { Username = string.Empty };
            return user;
        }

        [Route("post/login")]
        public async Task<string> PostLogin([FromBody] User user)
        {
            try
            {
                var login = await _db.Users.FirstOrDefaultAsync(a => a.Username == user.Username && a.Password == user.Password);
                if (login == null) throw new Exception("Authentication failed.");
                return login.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("post/new")]
        public async Task<string> Post([FromBody] User user)
        {
            try
            {
                if (_db.Users.Any(a => a.Username == user.Username)) return "The username is already used.";
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return user.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}