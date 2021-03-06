﻿using System;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;


namespace EGMS.BusinessAssociate.Domain
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        public AddressType AddressType { get; set; }
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
