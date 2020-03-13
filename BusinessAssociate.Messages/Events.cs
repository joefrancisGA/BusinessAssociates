using System;

namespace BusinessAssociate.Messages
{
    public static class Events
    {
        public static class V1
        {
            public class InternalAssociateCreated
            {
                public long Id { get; set; }

                public override string ToString()
                    => $"{nameof(InternalAssociateCreated)}";
            }

            public class InternalAssociateDeleted
            {
                public long Id { get; set; }

                public override string ToString()
                    => $"{nameof(InternalAssociateDeleted)}";
            }
        }
    }
}
