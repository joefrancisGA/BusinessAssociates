using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;

namespace EGMS.BusinessAssociate.Domain
{
    public class ExternalAssociate : EGMSAssociate
    {
        public ExternalAssociate(DUNSNumber dunsNumber, LongName longName, ShortName shortName,
            ExternalAssociateType externalBusinessAssociateType) : base (dunsNumber, longName, shortName)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalBusinessAssociateType = externalBusinessAssociateType;
        }

        public ExternalAssociate() { }


        public void AddAgentRelationship(AgentRelationship agentRelationship)
        {
            if (AgentRelationships == null)
            {
                AgentRelationships = new List<AgentRelationship>();
            }

            AgentRelationships.Add(agentRelationship);
        }

        public void AddOperatingContext(ExternalOperatingContext context)
        {
            if (OperatingContexts == null)
            {
                OperatingContexts = new List<OperatingContext>();
            }

            OperatingContexts.Add(context);
        }

        [Key]
        public new long Id { get; set; }

        // Properties unique to external business associates
        public ExternalAssociateType ExternalBusinessAssociateType { get; set; }
        public List<ExternalAssociate> PredecessorBusinessAssociates { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}