using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class User
    {
        public User()
        {
            ExamResults = new HashSet<ExamResult>();
            PracticeResults = new HashSet<PracticeResult>();
        }

        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Icon { get; set; }
        public string? Token { get; set; }

        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual ICollection<PracticeResult> PracticeResults { get; set; }
    }
}
