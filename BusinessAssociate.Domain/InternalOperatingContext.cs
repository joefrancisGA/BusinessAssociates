using System.Collections.Generic;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class InternalOperatingContext : OperatingContext
    {
        public InternalOperatingContext()
        {
            Status = Status.ACTIVE;
        }

        
        // ReSharper disable once UnusedMember.Local
        private List<AssetManagerRelationship> AssetManagerRelationships { get; set; }
    }
}