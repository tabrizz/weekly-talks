using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Migrations
    {
        public long Id { get; set; }
        public string Migration { get; set; }
        public int Batch { get; set; }
    }
}
