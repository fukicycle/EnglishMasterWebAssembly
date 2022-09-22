using EnglishMasterWebAssembly.Shared.Models;

namespace EnglishMasterWebAssembly.Client
{
    public static class Question
    {
        public static IEnumerable<Vocabulary> GetQuestions(this IEnumerable<Vocabulary> items)
        {
            return items.Select(a => new { a, o = Guid.NewGuid() }).OrderBy(a => a.o).Select(a => a.a);
        }

        public static IEnumerable<Vocabulary> GetAnswer(this IEnumerable<Vocabulary> items, Vocabulary vocabulary)
        {
            List<Vocabulary> answers = new();
            answers.Add(vocabulary);
            answers.AddRange(items.Where(a => a.WordId != vocabulary.WordId && a.PartOfSpeechId == vocabulary.PartOfSpeechId).Select(a => new { a, o = Guid.NewGuid() }).OrderBy(a => a.o).Select(a => a.a).Take(3));
            double avg = answers.GroupBy(a => a.Meaning).Average(a => a.Count());
            if (avg == 1) return answers.Select(a => new { a, o = Guid.NewGuid() }).OrderBy(a => a.o).Select(a => a.a);
            return items.GetAnswer(vocabulary);
        }
    }
}
