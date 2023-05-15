using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeaningOfWordLearningHistoryController : ControllerBase
    {
        private DB _db;
        public MeaningOfWordLearningHistoryController(DB db)
        {
            this._db = db;
        }
        [HttpGet("all")]
        public async Task<IEnumerable<MeaningOfWordLearningHistory>> Get()
        {
            return await _db.MeaningOfWordLearningHistories.ToListAsync();
        }


        public async Task<IActionResult> Post([FromBody] MeaningOfWordLearningHistory meaningOfWordLearningHistory)
        {
            try
            {
                _db.MeaningOfWordLearningHistories.Add(meaningOfWordLearningHistory);
                await _db.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
