using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private DB _db;
        public WordController(DB db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<Word>> Get()
        {
            return await _db.Words.ToListAsync();
        }
    }
}