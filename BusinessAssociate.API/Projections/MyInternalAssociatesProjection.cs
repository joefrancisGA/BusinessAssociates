using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociate.Messages;
using BusinessAssociates.RavenDB;
using Raven.Client.Documents.Session;

namespace BusinessAssociate.API.Projections
{
    public static class MyClassifiedAdsProjection
    {
        public static Func<Task> GetHandler(IAsyncDocumentSession session, object @event)
        {
            Func<long, string> getDbId =  ReadModels.MyInternalAssociateDetails.GetDatabaseId;

            return @event switch
            {
                Commands.V1.Create e =>
                    () => CreateOrUpdate(myInternalAssociate => myInternalAssociate.MyAssociates.Add(
                            new ReadModels.MyInternalAssociateDetails.MyInternalAssociates.MyAssociate { Id = e.Id }),
                        () => new ReadModels.MyInternalAssociateDetails.MyInternalAssociates
                        {
                            MyAssociates = new List<ReadModels.MyInternalAssociateDetails.MyInternalAssociates.MyAssociate>()
                        }),
                Commands.V1.Delete e =>
                    () => Update(myAd => myAd.MyAssociates
                            .RemoveAll(x => x.Id == e.Id)),
                _ => (Func<Task>)null
            };

            Task CreateOrUpdate(Action<ReadModels.MyInternalAssociateDetails.MyInternalAssociates> update,
                Func<ReadModels.MyInternalAssociateDetails.MyInternalAssociates> create)
                => session.UpsertItem(update, create);

            Task Update(Action<ReadModels.MyInternalAssociateDetails.MyInternalAssociates> update)
                => session.Update(update);

            //Task UpdateOneAd(long id, long adId,
            //    Action<ReadModels.MyInternalAssociateDetails.MyInternalAssociates> update)
            //    => Update(myAds =>
            //    {
            //        var ad = myAds.MyAssociates
            //            .FirstOrDefault(x => x.Id == adId);

            //        if (ad != null) update(ad);
            //    });
        }
    }
}
