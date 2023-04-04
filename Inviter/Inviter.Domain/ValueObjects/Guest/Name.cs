using Inviter.Domain.Exceptions;

namespace Inviter.Domain.ValueObjects.Guest
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new EmptyNameException();
            Value = value;
        }

        public static implicit operator Name(string value) => new(value);

        public static implicit operator string(Name value) => value.Value;

    }

}
