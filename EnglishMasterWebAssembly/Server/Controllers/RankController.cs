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

        public async Task<IEnumerable<Rank>> Get(int year, int month)
        {
            var ranking = await _db.MeaningOfWordLearningHistories.GroupBy(a => a.User).ToListAsync();
            var rank = 1;
            return ranking.OrderByDescending(a => a.Count()).Take(3).Select(a => new Rank
            {
                Nickname = a.Key.Nickname,
                Ranking = rank++,
                Count = a.Count()
            });
        }
    }
}

