using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class InternalBusinessAssociate : BusinessAssociate
    {
        public InternalBusinessAssociate(string dunsNumber, string longName, string shortName, InternalBusinessAssociateType internalBusinessAssociateType) : 
            base(dunsNumber, longName, shortName)
        {
            InternalBusinessAssociateType = internalBusinessAssociateType;
            Status = BusinessAssociateStatus.Active;
        }


        // Properties unique to Internal Business Associate
        public InternalBusinessAssociateType InternalBusinessAssociateType { get; set; }

        public List<AssetManagerRelationship> AssetManagerRelationships { get; set; }

        // It is questionable whether we need this property
        // If the InternalBusinessAssociateType is Parent or OperatingCompany, 
        //   then we know it is a parent.
        public bool IsParent { get; set; }
    }
}