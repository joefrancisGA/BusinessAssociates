using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;


namespace EGMS.BusinessAssociate.Domain
{
    public class ActingBAOperatingContext : OperatingContext
    {

        [Key]
        public new long Id { get; set; }

        public ProviderType ProviderType { get; set; }

        public string TPSID { get; set; }

        // JOEF:  I am a little skeptical about this field
        public string LegacyID { get; set; }
        public ExternalAssociateType ExternalBusinessAssociateType { get; set; }

        public Certification Certification { get; set; }
        public List<Customer> Customers { get; set; }
    }
}