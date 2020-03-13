using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class SubordinateAssociate : IBusinessAssociate
    {
        [Key]
        public long Id { get; set; }

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
        public Status Status { get; set; }
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