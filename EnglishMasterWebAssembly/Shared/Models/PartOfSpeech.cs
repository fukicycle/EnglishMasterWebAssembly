﻿using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models;

public partial class PartOfSpeech
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string InJapanese { get; set; } = null!;

    public virtual ICollection<MeaningOfWord> MeaningOfWords { get; set; } = new List<MeaningOfWord>();
}
