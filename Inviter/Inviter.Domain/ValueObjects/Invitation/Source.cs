using Inviter.Domain.Enums;
using Inviter.Domain.Exceptions;

namespace Inviter.Domain.ValueObjects.Invitation
{
    public record Source
    {
        public KnowledgeTypes Value { get;  }

        public Source(int value)
        {
            if (value < 0 || value > 15) throw new KnowledgeTypesOutOfRangeException(value.ToString());
            Value = (KnowledgeTypes)value;
        }

        public static implicit operator Source(int value) => new(value); 
    }
}
