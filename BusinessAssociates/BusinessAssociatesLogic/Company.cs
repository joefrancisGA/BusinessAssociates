using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAssociatesLogic
{
    public class SubordinateCompany
    {
        public int ID { get; set; }
        public string DisplayedIdentifier { get; set; }

        public string LongName { get; set; }
        public string ShortName { get; set; }
        public CompanyStatus CompanyStatus { get; set; }
        public SubordinateBusinessAssociateType SubordinateBusinessAssociateType { get; set; }
    }
}
