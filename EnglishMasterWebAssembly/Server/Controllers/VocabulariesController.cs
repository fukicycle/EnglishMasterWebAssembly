using EnglishMasterWebAssembly.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishMasterWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocabulariesController : ControllerBase
    {
        public IEnumerable<Vocabulary> GetVocabularies()
        {
            using (DB db = new DB())
            {
                return db.Vocabularies.Include(a => a.Word).Include(a => a.PartOfSpeech).ToList();
            }
        }
    }
}
