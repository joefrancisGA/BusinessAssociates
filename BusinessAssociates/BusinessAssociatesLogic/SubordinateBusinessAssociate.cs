using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class SubordinateBusinessAssociate : IBusinessAssociate
    {
        public void Create()
        {
        }

        public void Modify()
        {
        }

        public void AddOperatingContext()
        {
        }

        public string DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public BusinessAssociateStatus Status { get; set; }
        public List<Address> Addresses { get; set; }
        public int PrimaryAddress { get; set; }
        public List<EMail> EMails { get; set; }
        public int PrimaryEmail { get; set; }
        public List<Phone> Phones { get; set; }
        public int PrimaryPhone { get; set; }


        // Properties that are unique to SubordinateBusinessAssociate
        public SubordinateCompany SubordinateCompany { get; set; }
        public List<ActingBAOperatingContext> OperatingContexts { get; set; }

        // Do we really need a list of LifecycleEvent here>
        public LifecycleEvent LifecycleEvent { get; set; }
        public bool Deactivating { get; set; }
    }
}