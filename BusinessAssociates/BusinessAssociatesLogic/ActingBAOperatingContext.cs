using System.Collections.Generic;

namespace BusinessAssociatesLogic
{
    public class ActingBAOperatingContext : OperatingContext
    {
        public ProviderType ProviderType { get; set; }

        public string TPSID { get; set; }

        // JOEF:  I am a little skeptical about this field
        public string LegacyID { get; set; }
        public ExternalBusinessAssociateType ExternalBusinessAssociateType { get; set; }

        public Certification Certification { get; set; }
        public List<Customer> Customers { get; set; }
    }
}