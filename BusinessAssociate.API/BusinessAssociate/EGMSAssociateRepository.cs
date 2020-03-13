using System.Collections.Generic;
using System.Linq;
using EGMS.BusinessAssociate.Domain;
using EGMS.BusinessAssociate.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace BusinessAssociate.API.BusinessAssociate
{
    public class EGMSAssociateRepository : Repository<EGMSAssociate>
    {
        EGMSAssociatesContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<EGMSAssociatesContext>();
            builder.UseInMemoryDatabase("Test");
            return new EGMSAssociatesContext(builder.Options);
        }

        #region InternalAssociate



        public void AddInternalAssociate(InternalAssociate internalAssociate)
        {
            using var context = GetContext();
            context.InternalAssociates.Add(internalAssociate);
            context.SaveChanges();
        }

        public List<InternalAssociate> GetInternalAssociates()
        {
            return GetContext().InternalAssociates.ToList();
        }

        public InternalAssociate GetInternalAssociate(long id)
        {
            using var context = GetContext();
            return GetContext().InternalAssociates.Single(a => a.Id == id);
        }

        public void UpdateInternalAssociate(InternalAssociate internalAssociate)
        {
            using var context = GetContext();
            context.InternalAssociates.Update(internalAssociate);
            context.SaveChanges();
        }

        public void DeleteInternalAssociate(InternalAssociate internalAssociate)
        {
            using var context = GetContext();
            context.InternalAssociates.Remove(internalAssociate);
            context.SaveChanges();
        }

        public void AddInternalOperatingContext(InternalAssociate internalAssociate, InternalOperatingContext internalOperatingContext)
        {
            using var context = GetContext();
            internalAssociate.OperatingContexts.Add(internalOperatingContext);
            context.SaveChanges();
        }

        #endregion


        #region ExternalAssociate

        public void AddExternalAssociate(ExternalAssociate externalAssociate)
        {

        }

        public ExternalAssociate GetExternalAssociate(long id)
        {
            return (ExternalAssociate)new object();
        }

        public void UpdateExternalAssociate(ExternalAssociate externalAssociate)
        {

        }

        public void DeleteExternalAssociate(ExternalAssociate externalAssociate)
        {

        }

        #endregion
    }
}