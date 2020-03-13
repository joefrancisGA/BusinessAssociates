

using System.Collections.Generic;
using System.Linq;

namespace EGMS.BusinessAssociate.Domain.Common
{
    public abstract class Repository<T> where T : Entity
    {
        // ReSharper disable once StaticMemberInGenericType
        public static List<InternalAssociate> InternalAssociates = new List<InternalAssociate>();

        //protected readonly UnitOfWork _unitOfWork;

        //protected Repository(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public T GetById(long id)
        {
            if (typeof(T) == typeof(InternalAssociate))
            {
                return (from internalAssociate in InternalAssociates
                    where internalAssociate.Id == id
                    // ReSharper disable once SuspiciousTypeConversion.Global
                    select internalAssociate) as T;
            }

            return default(T);

            //return _unitOfWork.Get<T>(id);
        }

        public void Add(T entity)
        {
            if (typeof(T) == typeof(InternalAssociate))
            {
                InternalAssociates.Add(entity as InternalAssociate);
            }

            //_unitOfWork.SaveOrUpdate(entity);
        }

        public void Delete(T entity)
        {

        }
    }
}