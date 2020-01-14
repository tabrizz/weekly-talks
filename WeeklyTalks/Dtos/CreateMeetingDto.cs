using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyTalks.Dtos
{
    public class CreateMeetingDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OfficeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Quantity { get; set; }
    }
}
