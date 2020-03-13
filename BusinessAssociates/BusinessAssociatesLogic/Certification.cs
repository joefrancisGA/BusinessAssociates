using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAssociatesLogic
{
    public class Certification
    {
        // JOEF:  This seems questionable.  Why even have a Certification 
        //   object if it is not required?
        public bool IsCertificationRequired { get; set; }
        public bool InheritedCertification { get; set; }
        public CertificationStatus CertificationStatus { get; set; }
        public DateTime CertifiedDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
    }
}
