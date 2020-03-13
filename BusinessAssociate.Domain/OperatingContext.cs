using System;
using System.Collections.Generic;
using System.Security.Permissions;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    // Should this class be abstract?
    public abstract class OperatingContext
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }

        // TO DO:  Do we really have a set of roles for the operating context?
        public IEnumerable<Role> Roles { get; set; }
        public List<LifecycleEvent> LifecycleEvents { get; set; }
    }
}