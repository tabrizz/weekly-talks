using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class ModelHasRoles
    {
        public long RoleId { get; set; }
        public string ModelType { get; set; }
        public decimal ModelId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
