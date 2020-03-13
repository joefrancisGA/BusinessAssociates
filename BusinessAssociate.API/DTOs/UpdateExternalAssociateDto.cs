using EGMS.BusinessAssociate.Domain.Enums;

namespace BusinessAssociate.API.DTOs
{
    public class UpdateExternalAssociateDto
    {
        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public ExternalAssociateType ExternalAssociateType { get; set; }
    }
}
