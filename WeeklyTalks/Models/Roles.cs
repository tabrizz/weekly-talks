﻿using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class Roles
    {
        public Roles()
        {
            ModelHasRoles = new HashSet<ModelHasRoles>();
            RoleHasPermissions = new HashSet<RoleHasPermissions>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string GuardName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ModelHasRoles> ModelHasRoles { get; set; }
        public virtual ICollection<RoleHasPermissions> RoleHasPermissions { get; set; }
    }
}
