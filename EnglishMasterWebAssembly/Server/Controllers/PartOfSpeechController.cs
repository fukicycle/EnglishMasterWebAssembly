using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartOfSpeechController : ControllerBase
    {
        private DB _db;
        public PartOfSpeechController(DB db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<PartOfSpeech>> Get()
        {
            return await _db.PartOfSpeeches.ToListAsync();
        }
    }
}