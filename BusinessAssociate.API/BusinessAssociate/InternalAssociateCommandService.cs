using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociate.Messages;
using BusinessAssociates.EventSourcing;
using EGMS.BusinessAssociate.Domain;

namespace BusinessAssociate.API.BusinessAssociate
{
    public class InternalAssociateCommandService : ApplicationService<InternalAssociate>
    {
        public InternalAssociateCommandService(IAggregateStore store) : base(store)
        {
            CreateWhen<Commands.V1.Create>(
                cmd => InternalAssociateId.FromLong(cmd.Id),
                (cmd, id) => InternalAssociate.Create(InternalAssociateId.FromLong(id)));

            UpdateWhen<Commands.V1.Delete>(
                cmd => InternalAssociateId.FromLong(cmd.Id),
                (ad, cmd) => ad.Delete()
            );
        }
    }

}
