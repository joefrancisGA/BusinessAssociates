using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class User
    {
        [Key]
        public long Id { get; set; }
    }
}