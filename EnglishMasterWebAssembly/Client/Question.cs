using EnglishMasterWebAssembly.Shared.Models;

namespace EnglishMasterWebAssembly.Client
{
    public static class Question
    {
        public static List<Vocabulary> GetQuestions(this List<Vocabulary> items)
        {
            return items.Select(a => new { a, o = Guid.NewGuid() }).OrderBy(a => a.o).Select(a => a.a).ToList();
        }
    }
}
