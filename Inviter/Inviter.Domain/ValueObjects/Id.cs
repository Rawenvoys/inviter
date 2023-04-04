using Inviter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.ValueObjects
{
    public record Id
    {
        public Guid Value { get; }

        public Id(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new InvalidIdentityException();
            if (!Guid.TryParse(id, out Guid value)) throw new InvalidIdentityException(id);
            Value = value;
        }

        public Id(Guid value)
        {
            if (value == Guid.Empty) throw new InvalidIdentityException();
            Value = value;
        }

        public static implicit operator Id(string value) => new(value);
        public static implicit operator Id(Guid value) => new(value);

        public static implicit operator Guid(Id value) => value.Value;
        public static implicit operator string(Id value) => value.Value.ToString();
    }
}
