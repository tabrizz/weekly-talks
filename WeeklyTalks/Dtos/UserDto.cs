using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyTalks.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? OfficeId { get; set; }
        public string Role { get; set; }
    }
}
