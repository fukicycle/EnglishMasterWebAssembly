﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    public class RankController : ControllerBase
    {
        private DB _db;
        public RankController(DB db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Rank>> Get(DateTime start,DateTime end)
        {
            var ranking = await _db.MeaningOfWordLearningHistories.Where(a => a.Date.Date >= start && a.Date.Date <= end).GroupBy(a => a.User).ToListAsync();
            var rank = 1;
            return ranking.Where(a => a.Count() >= 1).OrderByDescending(a => a.Sum(b => b.BasePoint + b.AdditionalPoint)).Select(a => new Rank
            {
                Nickname = a.Key.Nickname,
                Ranking = rank++,
                CorrectRate = Math.Round(a.Count(b => b.QuestionMeaningOfWordId == b.AnswerMeaningOfWordId) / (a.Count() + 0.0m) * 100.0m, 2),
                Point = a.Sum(b => b.BasePoint + b.AdditionalPoint)
            });
        }

        [HttpGet("{id}")]
        public async Task<Rank?> Get(long id,DateTime start, DateTime end)
        {
            var ranking = await _db.MeaningOfWordLearningHistories.Where(a => a.Date.Date >= start && a.Date.Date <= end).GroupBy(a => a.User).ToListAsync();
            var rank = 1;
            //return ranking.Where(a => a.Count() >= 100).OrderByDescending(a => Math.Round(a.Count(b => b.QuestionMeaningOfWordId == b.AnswerMeaningOfWordId) / (a.Count() + 0.0m) * 100.0m, 2)).Select(a => new Rank
            return ranking.Where(a => a.Count() >= 1).OrderByDescending(a => a.Sum(b => b.BasePoint + b.AdditionalPoint)).Select(a => new Rank
            {
                UserID = a.Key.Id,
                Nickname = a.Key.Nickname,
                Ranking = rank++,
                CorrectRate = Math.Round(a.Count(b => b.QuestionMeaningOfWordId == b.AnswerMeaningOfWordId) / (a.Count() + 0.0m) * 100.0m, 2),
                Point = a.Sum(b => b.BasePoint + b.AdditionalPoint)
            }).SingleOrDefault(a => a.UserID == id) ?? new();
        }
    }
}

