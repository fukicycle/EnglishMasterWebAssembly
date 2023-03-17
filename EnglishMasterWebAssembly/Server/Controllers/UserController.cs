using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DB db;
        public UserController(DB db)
        {
            this.db = db;
        }
        public async Task<User> Get(long id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return new User { Email = string.Empty };
            return user;
        }

        [Route("post/login")]
        public async Task<string> PostLogin([FromBody] User user)
        {
            try
            {
                var login = await db.Users.FirstOrDefaultAsync(a => a.Email == user.Email && a.Password == user.Password);
                if (login == null) throw new Exception("Authentication failed.");
                return login.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
