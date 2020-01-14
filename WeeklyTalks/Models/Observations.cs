using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Observations
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int MeetingId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
