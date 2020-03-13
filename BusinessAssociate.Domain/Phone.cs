using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class Phone
    {
        [Key]
        public long Id { get; set; }

        public long PhoneNumber { get; set; }

        public PhoneType PhoneType { get; set; }

        public string Extension { get; set; }

        public bool IsPrimary { get; set; }
    }
}
