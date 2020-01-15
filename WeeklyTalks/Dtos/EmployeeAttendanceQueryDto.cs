using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyTalks.Dtos
{
    public class EmployeeAttendanceQueryDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Attended { get; set; }
        public string MissingReason { get; set; }
    }
}
