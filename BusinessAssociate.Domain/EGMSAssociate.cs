using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EGMS.BusinessAssociate.Domain.Common;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;

namespace EGMS.BusinessAssociate.Domain
{
    public abstract class EGMSAssociate : Entity
    {
        protected EGMSAssociate(DUNSNumber dunsNumber, LongName longName, ShortName shortName)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            OperatingContexts = new List<OperatingContext>();
            Users = new List<User>();
            Contacts = new List<Contact>();
        }

        protected EGMSAssociate() { }


        public Status Status { get; set; }

        private int _dunsNumber;

        [NotMapped]
        public DUNSNumber DUNSNumber
        {
            get => (DUNSNumber) _dunsNumber;
            set => _dunsNumber = value;
        }

        public string LongName { get; set; }
        public string ShortName { get; set; }


        // Collections
        public List<OperatingContext> OperatingContexts { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
