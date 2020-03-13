using EGMS.BusinessAssociate.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EGMS.BusinessAssociate.Domain
{
    public class EGMSAssociatesContext : DbContext
    {
        public EGMSAssociatesContext(DbContextOptions<EGMSAssociatesContext> options) : base (options)
        {

        }

        public DbSet<InternalAssociate> InternalAssociates { get; set; }
        public DbSet<ExternalAssociate> ExternalAssociates { get; set; }

        public DbSet<ActingBAOperatingContext> ActingBAOperatingContexts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentRelationship> AgentRelationships { get; set; }
        public DbSet<AgentUser> AgentUsers { get; set; }
        public DbSet<AssetManager> AssetManagers { get; set; }
        public DbSet<AssetManagerRelationship> AssetManagerRelationships { get; set; }
        public DbSet<AssetManagerUser> AssetManagerUsers { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactConfiguration> ContactConfigurations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EMail> EMails { get; set; }
        public DbSet<ExternalContact> ExternalContacts { get; set; }
        public DbSet<ExternalOperatingContext> ExternalOperatingContexts { get; set; }
        public DbSet<ExternalUser> ExternalUsers { get; set; }
        public DbSet<InternalContact> InternalContacts { get; set; }
        public DbSet<InternalOperatingContext> InternalOperatingContexts { get; set; }
        public DbSet<InternalUser> InternalUsers { get; set; }
        public DbSet<LifecycleEvent> LifecycleEvents { get; set; }
        public DbSet<OperatingContext> OperatingContexts { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SubordinateAssociate> SubordinateAssociates { get; set; }
        public DbSet<SubordinateCompany> SubordinateCompanies { get; set; }
        public DbSet<ThirdPartySupplier> ThirdPartySuppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperatingContext> UserOperatingContexts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DUNSNumber>().HasNoKey();
            modelBuilder.Entity<Agent>().Ignore("DUNSNumber");
        }
    }
}
