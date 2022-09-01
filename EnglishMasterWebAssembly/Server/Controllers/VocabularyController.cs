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
    public class VocabularyController : ControllerBase
    {
        private DB db;
        public VocabularyController(DB db)
        {
            this.db = db;
        }
        public List<Vocabulary> Get()
        {
            return db.Vocabularies.Include(a => a.Word).Include(a => a.PartOfSpeech).ToList();
        }
    }
}
