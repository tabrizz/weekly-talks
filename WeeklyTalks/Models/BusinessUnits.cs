﻿using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class BusinessUnits
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
