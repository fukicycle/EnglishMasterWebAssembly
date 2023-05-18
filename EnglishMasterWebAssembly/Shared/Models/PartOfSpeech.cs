namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class PartOfSpeech
    {
        public PartOfSpeech()
        {
            MeaningOfWords = new HashSet<MeaningOfWord>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string InJapanese { get; set; } = null!;

        public virtual ICollection<MeaningOfWord> MeaningOfWords { get; set; }
    }
}