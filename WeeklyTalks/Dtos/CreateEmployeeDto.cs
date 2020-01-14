using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyTalks.Dtos
{
    public class CreateEmployeeDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string JobTitle { get; set; }
        public int OfficeId { get; set; }
        public short Status { get; set; }
    }
}
