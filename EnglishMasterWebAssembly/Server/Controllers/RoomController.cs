using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private DB db;
        public RoomController(DB db)
        {
            this.db = db;
        }

        public async Task<List<Room>> Get()
        {
            return await db.Rooms.Where(a => a.IsOpen == 1).ToListAsync();
        }
    }
}

