using EGMS.BusinessAssociate.Domain.Enums;

namespace BusinessAssociate.API.DTOs
{
    public class CreateExternalAssociateDto
    {
        // Needed for serialization
        public CreateExternalAssociateDto() { }

        public CreateExternalAssociateDto(int dunsNumber, string longName, string shortName, ExternalAssociateType externalAssociateType)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalAssociateType = externalAssociateType;
        }

        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public ExternalAssociateType ExternalAssociateType { get; set; }
    }
}
