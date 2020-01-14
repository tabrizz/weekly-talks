using System;
using System.Collections.Generic;

namespace WeeklyTalks.Models
{
    public partial class ModelHasPermissions
    {
        public long PermissionId { get; set; }
        public string ModelType { get; set; }
        public decimal ModelId { get; set; }

        public virtual Permissions Permission { get; set; }
    }
}
