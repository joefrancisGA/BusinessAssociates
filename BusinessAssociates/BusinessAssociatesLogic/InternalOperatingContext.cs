using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class InternalOperatingContext : OperatingContext
    {
        public InternalOperatingContext()
        {
            Status = OperatingContextStatus.Active;
        }



        private List<AssetManagerRelationship> AssetManagerRelationships { get; set; }
    }
}