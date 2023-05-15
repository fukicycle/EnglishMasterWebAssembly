using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class Word
    {
        public Word()
        {
            MeaningOfWords = new HashSet<MeaningOfWord>();
        }

        public long Id { get; set; }
        public string Word1 { get; set; } = null!;

        public virtual ICollection<MeaningOfWord> MeaningOfWords { get; set; }
    }
}
