namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class Idiom
    {
        public Idiom()
        {
            MeaningOfIdioms = new HashSet<MeaningOfIdiom>();
        }

        public long Id { get; set; }
        public string Idiom1 { get; set; } = null!;

        public virtual ICollection<MeaningOfIdiom> MeaningOfIdioms { get; set; }
    }
}