using System;
using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class AssetManagerRelationship
    {
        public AssetManagerRelationship(InternalBusinessAssociate principal,
            ExternalBusinessAssociate assetManager)
        {

        }

        public InternalBusinessAssociate Principal { get; set; }
        public ExternalBusinessAssociate AssetManager { get; set; }
        public List<UserOperatingContext> AssetManagerUserList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}