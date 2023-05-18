using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeaningOfIdiomController : ControllerBase
    {
        private DB _db;
        public MeaningOfIdiomController(DB db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<MeaningOfIdiom>> Get()
        {
            return await _db.MeaningOfIdioms.ToListAsync();
        }
    }
}