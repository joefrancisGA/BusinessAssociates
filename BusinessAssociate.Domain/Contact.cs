using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }
    }
}