using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class OfficeUser
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
