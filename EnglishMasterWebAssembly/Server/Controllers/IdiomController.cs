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
    public class IdiomController : ControllerBase
    {
        private DB _db;
        public IdiomController(DB db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<Idiom>> Get()
        {
            return await _db.Idioms.ToListAsync();
        }
    }
}
