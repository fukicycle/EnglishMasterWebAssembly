﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public class WordResult
    {
        public string Word { get; set; } = null!;
        public long WordID { get; set; }
        public string Answer { get; set; } = null!;
        public string Question { get; set; } = null!;
        public bool IsCorrect { get; set; }
        public DateTime Date { get; set; }
    }
}
