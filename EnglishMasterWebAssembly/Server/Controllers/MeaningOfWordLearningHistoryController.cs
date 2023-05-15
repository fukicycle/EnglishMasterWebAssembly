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

        [HttpGet]
        public async Task<IEnumerable<WordResult>> Get(int count, int userId)
        {
            var list = await _db.MeaningOfWordLearningHistories
                .Include(a => a.QuestionMeaningOfWord)
                .ThenInclude(a => a.Word)
                .Include(a => a.AnswerMeaningOfWord)
                .ThenInclude(a => a.Word)
                .Where(a => a.UserId == userId).ToListAsync();
            return list.OrderByDescending(a => a.Date).Take(count).Select(a => new WordResult
            {
                Word = a.QuestionMeaningOfWord.Word.Word1,
                WordID = a.QuestionMeaningOfWord.WordId,
                Question = a.QuestionMeaningOfWord.Meaning,
                Answer = a.AnswerMeaningOfWord.Meaning,
                IsCorrect = a.AnswerMeaningOfWordId == a.QuestionMeaningOfWordId,
                Date = a.Date
            });
        }

        [HttpPost]
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

        [HttpGet("summary")]
        public async Task<IEnumerable<Summary>> Get(long userId)
        {
            return await _db.MeaningOfWordLearningHistories.Where(a => a.UserId == userId).GroupBy(a => a.Date.Date).Select(a => new Summary
            {
                Total = a.Count(),
                Correct = a.Count(b => b.QuestionMeaningOfWordId == b.AnswerMeaningOfWordId),
                Incorrect = a.Count(b => b.QuestionMeaningOfWordId != b.AnswerMeaningOfWordId),
                Date = a.Key
            }).ToListAsync();
        }
    }
}
