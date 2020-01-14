using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class OauthClients
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Redirect { get; set; }
        public short PersonalAccessClient { get; set; }
        public short PasswordClient { get; set; }
        public short Revoked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
