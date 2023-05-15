using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public class Summary
    {
        public int Total { get; set; }
        public int Correct { get; set; }
        public int Incorrect { get; set; }
        public DateTime Date { get; set; }
    }
}
