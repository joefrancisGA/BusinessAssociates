using Microsoft.EntityFrameworkCore;
using System;
using EGMS.Domain.Contacts;
using EGMS.Common.Domain.Address;
using Facilities.Domain;

namespace EGMS.Data.Contacts
{
    public class ContactContext: DbContext
    {
        public DbSet<Domain.Contacts.Contact> Contacts { get; set; }
        public DbSet<Name> Name { get; set; }
        public DbSet<LocationAddress> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connstring = "Data Source = (localdb)\\MSSqlLocalDB; Initial Catalog = Contacts";
            optionsBuilder.UseSqlServer(connstring);
            
        }
    }
}
