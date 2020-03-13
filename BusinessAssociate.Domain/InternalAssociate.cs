using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessAssociate.Messages;
using BusinessAssociates.EventSourcing;
using EGMS.BusinessAssociate.Domain.Common;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;
using static BusinessAssociate.Messages.Events;

namespace EGMS.BusinessAssociate.Domain
{

    public class InternalAssociateId : AggregateId<InternalAssociate>
    { 
        InternalAssociateId(long value) : base(value) { }

        public static InternalAssociateId FromLong(long value)
            => new InternalAssociateId(value);
    }

    public class InternalAssociate : AggregateRoot
    {

        public InternalAssociate(DUNSNumber dunsNumber, LongName longName, ShortName shortName, InternalAssociateType internalBusinessAssociateType)
        {
            InternalBusinessAssociateType = internalBusinessAssociateType;
            Status = Status.ACTIVE;
            AssetManagerRelationships = new List<AssetManagerRelationship>();
        }


        public InternalAssociate() { }
        
        public InternalOperatingContext AddOperatingContext()
        {
            InternalOperatingContext context = new InternalOperatingContext
            {
                Status = Status.ACTIVE, StartDate = DateTime.Now
            };

            return context;
        }

        public static InternalAssociate Create(InternalAssociateId id)
        {
            InternalAssociate internalAssociate = new InternalAssociate();

            internalAssociate.Apply(
                new V1.InternalAssociateCreated
                {
                    Id = id
                }
            );

            return internalAssociate;
        }

        //public static void Delete(InternalAssociateId id)
        //{
        //    InternalAssociate internalAssociate = new InternalAssociate();

        //    internalAssociate.Apply(
        //        new V1.InternalAssociateDeleted
        //        {
        //            Id = id
        //        }
        //    );
        //}

        public void Delete()
            => Apply(
                new Commands.V1.Delete
                {
                    Id = Id
                }
            );

        [Key]
        public long Id { get; set; }

        public Status Status { get; set; }


        // Collections
        public List<OperatingContext> OperatingContexts { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case V1.InternalAssociateCreated e:
                    Id = e.Id;
                    Status = Status.ACTIVE;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = true;

            //var valid =
            //    OwnerId != null &&
            //    (State switch
            //    {
            //        ClassifiedAdState.PendingReview =>
            //        Title != null
            //        && Text != null
            //        && Price?.Amount > 0,
            //        ClassifiedAdState.Active =>
            //        Title != null
            //        && Text != null
            //        && Price?.Amount > 0
            //        && ApprovedBy != null,
            //        _ => true
            //    });

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(
                    this, $"Post-checks failed"
                );
        }

        // Properties unique to Internal Business Associate
        public InternalAssociateType InternalBusinessAssociateType { get; set; }

        public List<AssetManagerRelationship> AssetManagerRelationships { get; set; }

        // It is questionable whether we need this property
        // If the InternalBusinessAssociateType is Parent or OperatingCompany, 
        //   then we know it is a parent.
        public bool IsParent { get; set; }
    }
}