﻿using System;
using System.ComponentModel.DataAnnotations;
using EGMS.BusinessAssociate.Domain.Enums;

namespace EGMS.BusinessAssociate.Domain
{
    public class Certification
    {
        [Key]
        public long Id { get; set; }


        // JOEF:  This seems questionable.  Why even have a Certification 
        //   object if it is not required?
        public bool IsCertificationRequired { get; set; }
        public bool InheritedCertification { get; set; }
        public CertificationStatus CertificationStatus { get; set; }
        public DateTime CertifiedDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
    }
}
