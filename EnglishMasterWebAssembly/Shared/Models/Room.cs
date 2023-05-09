using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class Room
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string Code { get; set; } = null!;
        public DateTime Date { get; set; }
        public byte IsOpen { get; set; }
    }
}
