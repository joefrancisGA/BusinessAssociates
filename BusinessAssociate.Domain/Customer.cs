using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
    }
}