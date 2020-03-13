using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain
{
    public class LifecycleEvent
    {
        [Key]
        public long Id { get; set; }
    }
}
