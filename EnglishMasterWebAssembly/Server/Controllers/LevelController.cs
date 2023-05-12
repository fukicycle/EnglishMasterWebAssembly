using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private DB _db;
        public LevelController(DB db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<Level>> Get()
        {
            return await _db.Levels.ToListAsync();
        }
    }
}
