using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class Company
    {
        public int ID { get; set; }
        public string DisplayedIdentifier { get; set; }

        public string LongName { get; set; }
        public string ShortName { get; set; }
        public Status Status { get; set; }
        public SubordinateAssociateType SubordinateBusinessAssociateType { get; set; }
    }
}
