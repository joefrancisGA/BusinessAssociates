using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class ExternalOperatingContext : ActingBAOperatingContext
    {
        public ExternalOperatingContext()
        {
            Status = Status.PENDING;
        }

        public ExternalOperatingContext(ProviderType providerType)
        {
            ProviderType = providerType;
        }


        [Key]
        public new long Id { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}