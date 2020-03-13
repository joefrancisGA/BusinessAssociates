using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class ExternalBusinessAssociate : BusinessAssociate
    {
        public ExternalBusinessAssociate(string dunsNumber, string longName, string shortName, ExternalBusinessAssociateType externalBusinessAssociateType) : 
            base (dunsNumber, longName, shortName)
        {
            ExternalBusinessAssociateType = externalBusinessAssociateType;
            Status = BusinessAssociateStatus.Pending;
        }

        public void AddAgentRelationship(AgentRelationship agentRelationship)
        {
            AgentRelationships.Add(agentRelationship);
        }

        // Properties unique to external business associates
        public ExternalBusinessAssociateType ExternalBusinessAssociateType { get; set; }
        public List<ExternalBusinessAssociate> PredecessorBusinessAssociates { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}