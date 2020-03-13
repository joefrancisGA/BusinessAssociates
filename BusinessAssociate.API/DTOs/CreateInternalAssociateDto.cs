using EGMS.BusinessAssociate.Domain.Enums;

namespace BusinessAssociate.API.DTOs
{
    public class CreateInternalAssociateDto
    {
        // Needed for serialization
        public CreateInternalAssociateDto() { }

        public CreateInternalAssociateDto(int dunsNumber, string longName, string shortName, InternalAssociateType internalAssociateType)
        {

            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            InternalAssociateType = internalAssociateType;
        }

        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public InternalAssociateType InternalAssociateType { get; set; }
    }
}
