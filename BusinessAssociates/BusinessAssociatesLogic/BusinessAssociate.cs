using System.Collections.Generic;
using System.Dynamic;

namespace BusinessAssociatesLogic
{
    public class BusinessAssociate : IBusinessAssociate
    {
        public BusinessAssociate(string dunsNumber, string longName, string shortName)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
        }

        public void Create()
        {
        }

        public void Modify()
        {
        }

        public void AddOperatingContext()
        {
        }

        public void AddOperatingContext(OperatingContext operatingContext)
        {
        }

        public string DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public BusinessAssociateStatus Status { get; set; }
        public List<OperatingContext> OperatingContexts { get; set; }

        public List<Address> Addresses { get; set; }
        public int PrimaryAddress { get; set; }
        public List<EMail> EMails { get; set; }
        public int PrimaryEmail { get; set; }
        public List<Phone> Phones { get; set; }
        public int PrimaryPhone { get; set; }
    }
}