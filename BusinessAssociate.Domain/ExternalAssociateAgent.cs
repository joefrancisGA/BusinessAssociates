using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class ExternalAssociateAgent
    {
        [Key]
        public long Id { get; set; }
        public long ExternalAssociateId { get; set; }
        public long AgentId { get; set; }

        public ExternalAssociate ExternalAssociate { get; set; }
        public Agent Agent { get; set; }
    }
}