using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociate.Messages;
using BusinessAssociates.RavenDB;
using Raven.Client.Documents.Session;

namespace BusinessAssociate.API.Projections
{
    public static class InternalAssociateDetailsProjection
    {
        public static Func<Task> GetHandler(
            IAsyncDocumentSession session,
            object @event)
        {
            return @event switch
            {
                Commands.V1.Create e =>
                () => Create(e.Id)
            };

            string GetDbId(long id)
                => ReadModels.InternalAssociateDetails.GetDatabaseId(id);

            Task Create(long id)
                => session.Create<ReadModels.InternalAssociateDetails>(
                    x =>
                    {
                        x.Id = GetDbId(id);
                    }
                );

            Task Update(long id, Action<ReadModels.InternalAssociateDetails> update)
                => session.Update(update);

            Task Delete(long id)
            {
                session.Delete(GetDbId(id));
                return Task.CompletedTask;
            }
        }
    }
}
