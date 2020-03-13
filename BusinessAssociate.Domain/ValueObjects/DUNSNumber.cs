using CSharpFunctionalExtensions;

namespace EGMS.BusinessAssociate.Domain.ValueObjects
{
    public class DUNSNumber : ValueObject<DUNSNumber>
    {

        public DUNSNumber() { }

        private DUNSNumber(int value)
        {
            Value = value;
        }

        public int Value { get; }

        
        public static Result<DUNSNumber> Create(int dunsNumber)
        {
            if (dunsNumber < 100000000)
                return Result.Failure<DUNSNumber>("DUNSNumber is too short");

            if (dunsNumber > 999999999)
                return Result.Failure<DUNSNumber>("DUNSNumber is too long");

            return Result.Ok(new DUNSNumber(dunsNumber));
        }

        protected override bool EqualsCore(DUNSNumber dunsNumber)
        {
            return dunsNumber.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator int(DUNSNumber dunsNumber)
        {
            return dunsNumber.Value;
        }

        public static explicit operator DUNSNumber(int dunsNumber)
        {
            return Create(dunsNumber).Value;
        }
    }
}