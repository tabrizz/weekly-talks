using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyTalks.Models;

namespace WeeklyTalks.Dtos
{
    public class StoreAttendanceMeetingDto
    {
        public long Id { get; set; }
        public IEnumerable<EmployeeAttendanceDto> EmployeesList { get; set; }
        public IEnumerable<Employees> Guests { get; set; }
        public IEnumerable<string> Captures { get; set; }
        public DateTime SelectedDate { get; set; }

    }
}
