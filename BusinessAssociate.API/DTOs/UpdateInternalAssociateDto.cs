using EGMS.BusinessAssociate.Domain.Enums;

namespace BusinessAssociate.API.BusinessAssociate
{
    public class UpdateInternalAssociateDto
    {
       public int DUNSNumber { get; set; }
       public string LongName { get; set; }
       public string ShortName { get; set; }
       public InternalAssociateType InternalBusinessAssociateType { get; set; }
    }
}
