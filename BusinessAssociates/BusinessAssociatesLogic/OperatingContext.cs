using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessAssociatesLogic
{
    public class OperatingContext
    {
        public string LDC { get; set; }
        public OperatingContextStatus Status { get; set; }
        public List<LifecycleEvent> LifecycleEvents { get; set; }
        public bool Deactivating { get; set; }

        public DateTime StartDate { get; set;}
    }
}