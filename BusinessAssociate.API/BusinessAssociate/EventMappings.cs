using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociate.Messages;
using BusinessAssociates.EventSourcing;

namespace BusinessAssociate.API.BusinessAssociate
{
    public static class EventMappings
    {
        public static void MapEventTypes()
        {
            TypeMapper.Map<Events.V1.InternalAssociateCreated>("InternalAssociateCreated");
            TypeMapper.Map<Events.V1.InternalAssociateDeleted>("InternalAssociateDeleted");
        }
    }
}
