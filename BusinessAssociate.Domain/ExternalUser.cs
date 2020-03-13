using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Common;

namespace EGMS.BusinessAssociate.Domain
{
    public class ExternalUser : Entity
    {
        [Key]
        public new long Id { get; set; }
    }
}