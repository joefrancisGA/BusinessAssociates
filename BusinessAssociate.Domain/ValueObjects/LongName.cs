using CSharpFunctionalExtensions;

namespace EGMS.BusinessAssociate.Domain.ValueObjects
{
    public class LongName : ValueObject<LongName>
    {
        public string Value { get; }

        private LongName(string value)
        {
            Value = value;
        }

        public static Result<LongName> Create(string longName)
        {
            longName = (longName ?? string.Empty).Trim();

            if (longName.Length == 0)
                return Result.Failure<LongName>("Long name should not be empty");

            if (longName.Length > 100)
                return Result.Failure<LongName>("Customer name is too long");

            return Result.Ok(new LongName(longName));
        }

        protected override bool EqualsCore(LongName longName)
        {
            return longName.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(LongName longName)
        {
            return longName.Value;
        }

        public static explicit operator LongName(string longName)
        {
            return Create(longName).Value;
        }
    }
}