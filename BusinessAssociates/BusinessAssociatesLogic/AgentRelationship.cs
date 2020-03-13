using System;
using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class AgentRelationship
    {
        public AgentRelationship(ExternalBusinessAssociate principal, ExternalBusinessAssociate agent)
        {
            Principal = principal;
            Agent = agent;
        }

        public ExternalBusinessAssociate Principal { get; set; }
        public ExternalBusinessAssociate Agent { get; set; }
        public List<UserOperatingContext> AgentUserList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}