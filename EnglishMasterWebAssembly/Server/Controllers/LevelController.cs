using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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