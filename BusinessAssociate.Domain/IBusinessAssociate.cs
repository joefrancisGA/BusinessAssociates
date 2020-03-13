using System.Collections.Generic;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public interface IBusinessAssociate
    {
        void Create();
        void Modify();
        void AddOperatingContext();

        string DUNSNumber { get; set; }
        string LongName { get; set; }
        string ShortName { get; set; }
        Status Status { get; set; }

        List<Address> Addresses { get; set; }
        int PrimaryAddress { get; set; }

        List<EMail> EMails { get; set; }
        int PrimaryEmail { get; set; }

        List<Phone> Phones { get; set; }
        int PrimaryPhone { get; set; }
    }
}