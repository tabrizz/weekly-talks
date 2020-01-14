﻿using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class OauthRefreshTokens
    {
        public string Id { get; set; }
        public string AccessTokenId { get; set; }
        public short Revoked { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
