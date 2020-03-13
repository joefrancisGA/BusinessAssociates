using CSharpFunctionalExtensions;

namespace EGMS.BusinessAssociate.Domain.ValueObjects
{
    public class ShortName : ValueObject<ShortName>
    {
        public string Value { get; }

        private ShortName(string value)
        {
            Value = value;
        }

        public static Result<ShortName> Create(string longName)
        {
            longName = (longName ?? string.Empty).Trim();

            if (longName.Length == 0)
                return Result.Failure<ShortName>("Short name should not be empty");

            if (longName.Length > 100)
                return Result.Failure<ShortName>("Short name is too long");

            return Result.Ok(new ShortName(longName));
        }

        protected override bool EqualsCore(ShortName shortName)
        {
            return shortName.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(ShortName shortName)
        {
            return shortName.Value;
        }

        public static explicit operator ShortName(string shortName)
        {
            return Create(shortName).Value;
        }
    }
}