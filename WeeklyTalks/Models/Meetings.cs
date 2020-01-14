using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Meetings
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OfficeId { get; set; }
        public string SelfiePic { get; set; }
        public string DocumentPic { get; set; }
        public short Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
