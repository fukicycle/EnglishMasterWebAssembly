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
    public class MeaningOfIdiomController : ControllerBase
    {
        private DB db;
        public MeaningOfIdiomController(DB db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<MeaningOfIdiom>> Get()
        {
            return await db.MeaningOfIdioms.ToListAsync();
        }
    }
}
