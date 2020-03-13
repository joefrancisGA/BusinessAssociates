using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAssociatesLogic
{
    public class Phone
    {
        public long PhoneNumber { get; set; }

        public PhoneType PhoneType { get; set; }

        public string Extension { get; set; }

        public bool IsPrimary { get; set; }
    }
}
