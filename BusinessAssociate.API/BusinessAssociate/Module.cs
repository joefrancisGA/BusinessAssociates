using System;
using BusinessAssociate.API.Projections;
using BusinessAssociates.EventStore;
using BusinessAssociates.RavenDB;
using EventStore.ClientAPI;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

//using Marketplace.Ads.ClassifiedAds;
//using Marketplace.Ads.Domain.Shared;
//using Marketplace.Ads.Projections;
//using Marketplace.RavenDb;

//using Raven.Client.Documents;
//using Raven.Client.Documents.Session;
//using static Marketplace.Ads.Projections.ReadModels;

namespace BusinessAssociate.API.BusinessAssociate
{
    public static class AdsModule
    {
        const string SubscriptionName = "adsSubscription";

        public static IMvcCoreBuilder AddAdsModule(
            this IMvcCoreBuilder builder,
            string databaseName)
        {
            EventMappings.MapEventTypes();

            builder.Services.AddSingleton(
                c =>
                    new InternalAssociateCommandService(
                        new EsAggregateStore(c.GetEsConnection())
                    )
            );

            builder.Services.AddSingleton(
                c =>
                {
                    var store = c.GetRavenStore();
                    store.CheckAndCreateDatabase(databaseName);

                    IAsyncDocumentSession GetSession()
                        => c.GetRavenStore()
                            .OpenAsyncSession(databaseName);

                    return new SubscriptionManager(
                        c.GetEsConnection(),
                        new RavenDbCheckpointStore(
                            GetSession, SubscriptionName
                        ),
                        SubscriptionName,
                        new RavenDbProjection<ReadModels.InternalAssociateDetails>(
                            GetSession,
                            InternalAssociateDetailsProjection.GetHandler
                        ),
                        new RavenDbProjection<ReadModels.MyInternalAssociateDetails>(
                            GetSession,
                            MyClassifiedAdsProjection.GetHandler
                        )
                    );
                }
            );

            builder.AddApplicationPart(typeof(AdsModule).Assembly);

            return builder;
        }

        static IDocumentStore GetRavenStore(
            this IServiceProvider provider
        )
            => provider.GetRequiredService<IDocumentStore>();

        // JOEF:  Changed this to public from reference example
        public static IEventStoreConnection GetEsConnection(
            this IServiceProvider provider
        )
            => provider.GetRequiredService<IEventStoreConnection>();
    }
}