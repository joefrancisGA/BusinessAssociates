using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAssociatesLogic
{
    public class Address
    {
        public AddressType AdddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public GeographicState GeographicState { get; set; }
        public string PostalCode { get; set; }
        public CountryCode CountryCode { get; set; }
        public string Attention { get; set; }
        public bool IsPrimary { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
