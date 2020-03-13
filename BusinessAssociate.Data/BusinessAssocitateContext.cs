using Microsoft.EntityFrameworkCore;
using System;
using EGMS.BusinessAssociate.Domain;

namespace EGMS.BusinessAssociate.Data
{
    public class BusinessAssocitateContext: DbContext
    {
        public DbSet<Domain.BusinessAssociate> BusinessAssociates { get; set; }
        public DbSet<OperatingContext> OperatingContexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connstring = "Data Source = (localdb)\\MSSqlLocalDB; Initial Catalog = Contacts";
            optionsBuilder.UseSqlServer(connstring);

        }
    }
}
