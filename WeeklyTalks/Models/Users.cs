using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }
        public int? OfficeId { get; set; }
        public string Role { get; set; }
    }
}
