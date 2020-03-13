using System.Collections.Generic;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;

namespace EGMS.BusinessAssociate.Domain
{
    public class Agent : ExternalAssociate
    {
        public Agent(DUNSNumber dunsNumber, LongName longName, ShortName shortName,
            ExternalAssociateType externalBusinessAssociateType) : base(dunsNumber, longName, shortName, externalBusinessAssociateType)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalBusinessAssociateType = externalBusinessAssociateType;
        }

        public Agent() { }

        public ICollection<ExternalAssociateAgent> ExternalAssociateAgents { get; set; }
    }
}