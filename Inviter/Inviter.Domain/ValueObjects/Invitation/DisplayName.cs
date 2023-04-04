using Inviter.Domain.Exceptions;

namespace Inviter.Domain.ValueObjects.Invitation
{
    public record DisplayName
    {
        public string Value { get; }

        public DisplayName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new EmptyDisplayNameException();
            Value = value;
        }

        public static implicit operator DisplayName(string value) => new(value);

        public static implicit operator string(DisplayName value) => value.Value;
    }
}
