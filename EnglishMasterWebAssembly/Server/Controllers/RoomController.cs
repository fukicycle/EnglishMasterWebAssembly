using EnglishMasterWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private DB _db;
        public RoomController(DB db)
        {
            this._db = db;
        }

        public async Task<List<Room>> Get()
        {
            return await _db.Rooms.Where(a => a.IsOpen).ToListAsync();
        }
    }
}