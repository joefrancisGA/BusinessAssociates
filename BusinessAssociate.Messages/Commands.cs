using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAssociate.Messages
{
    public static class Commands
    {
        public static class V1
        {
            public class Create
            {
                public long Id { get; set; }

                public override string ToString() => $"CreateInternalAssociate {Id}";
            }

            public class Delete
            {
                public long Id { get; set; }

                public override string ToString() => $"DeleteInternalAssociate {Id}";
            }
        }
    }
}
