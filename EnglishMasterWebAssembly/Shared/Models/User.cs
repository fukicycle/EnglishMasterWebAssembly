using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Server.Models
{
    public partial class User
    {
        public User()
        {
            ExamResults = new HashSet<ExamResult>();
            PracticeResults = new HashSet<PracticeResult>();
        }

        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual ICollection<PracticeResult> PracticeResults { get; set; }
    }
}
