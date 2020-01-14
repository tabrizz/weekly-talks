using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class RoleHasPermissions
    {
        public long PermissionId { get; set; }
        public long RoleId { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Roles Role { get; set; }
    }
}
