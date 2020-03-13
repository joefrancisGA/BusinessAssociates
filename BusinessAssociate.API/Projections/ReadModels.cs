using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessAssociate.API.Projections
{
    public static class ReadModels
    {
        public class InternalAssociateDetails
        {
            public string Id { get; set; }
            public Guid SellerId { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string CurrencyCode { get; set; }
            public string Description { get; set; }
            public List<string> PhotoUrls { get; set; }
                = new List<string>();

            public static string GetDatabaseId(long id)
                => $"ClassifiedAdDetails/{id}";
        }

        public class MyInternalAssociateDetails
        {
            public string Id { get; set; }
            public List<MyInternalAssociates> MyAds { get; set; }

            public class MyInternalAssociates
            {
                public List<MyAssociate> MyAssociates { get; set; }

                public class MyAssociate
                {
                    public long Id { get; set; }
                    public string Title { get; set; }
                    public decimal Price { get; set; }
                    public string Description { get; set; }
                    public string Status { get; set; }

                    public List<string> PhotoUrls { get; set; }
                        = new List<string>();
                }
            }

            public static string GetDatabaseId(long id)
                => $"MyClassifiedAds/{id}";
        }
    }
}
