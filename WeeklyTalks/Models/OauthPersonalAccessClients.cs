using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class OauthPersonalAccessClients
    {
        public long Id { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
