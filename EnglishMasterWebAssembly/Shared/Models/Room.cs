using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomUsers = new HashSet<RoomUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool IsOpen { get; set; }
        public bool IsPrivate { get; set; }

        public virtual ICollection<RoomUser> RoomUsers { get; set; }
    }
}
