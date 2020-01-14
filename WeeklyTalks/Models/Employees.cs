using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Employees
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string JobTitle { get; set; }
        public int OfficeId { get; set; }
        public short Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
