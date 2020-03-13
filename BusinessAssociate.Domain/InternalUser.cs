using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class InternalUser
    {
        [Key]
        public long Id { get; set; }
    }
}