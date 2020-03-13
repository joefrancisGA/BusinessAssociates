using System.ComponentModel.DataAnnotations;

namespace EGMS.BusinessAssociate.Domain.Common
{
    public abstract class Entity
    {
        protected bool Equals(Entity other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        [Key]
        public virtual long Id { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            //if (GetRealType() != other.GetRealType())
            //    return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        //public override int GetHashCode()
        //{
        //    return (GetRealType().ToString() + Id).GetHashCode();
        //}

        //private Type GetRealType()
        //{
        //    return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        //}
    }
}

