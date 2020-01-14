using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class EmployeeMeeting
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public int MeetingId { get; set; }
        public short Attended { get; set; }
        public string MissingReason { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
