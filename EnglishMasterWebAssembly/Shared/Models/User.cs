﻿using System;
using System.Collections.Generic;

namespace EnglishMasterWebAssembly.Shared.Models;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Token { get; set; }

    public string Nickname { get; set; } = null!;

    public virtual ICollection<MeaningOfWordLearningHistory> MeaningOfWordLearningHistories { get; set; } = new List<MeaningOfWordLearningHistory>();

    public virtual ICollection<RoomUser> RoomUsers { get; set; } = new List<RoomUser>();
}
