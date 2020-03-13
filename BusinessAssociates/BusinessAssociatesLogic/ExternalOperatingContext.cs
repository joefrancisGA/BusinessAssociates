using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class ExternalOperatingContext : ActingBAOperatingContext
    {
        public ExternalOperatingContext()
        {
            Status = OperatingContextStatus.Pending;
        }

        public ExternalOperatingContext(ProviderType providerType)
        {
            ProviderType = providerType;
        }

        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}