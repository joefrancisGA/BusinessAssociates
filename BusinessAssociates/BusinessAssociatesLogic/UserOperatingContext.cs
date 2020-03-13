using System;

namespace BusinessAssociatesLogic
{
    public class UserOperatingContext : OperatingContext
    {
        public Role Role { get; set; }
        public int FacilityID { get; set; }
        public ExternalBusinessAssociate BusinessAssociate { get; set; }
        public User User { get; set; }


        // The specs call for StartDate, but that is inherited from 
        //   the generic OperatingContext

        public DateTime EndDate { get; set; }
    }
}