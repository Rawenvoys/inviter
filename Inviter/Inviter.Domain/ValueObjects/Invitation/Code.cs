using Inviter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.ValueObjects.Invitation
{
    public record Code
    {
        public Guid Value { get; }

        public Code(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new WrongCodeException();
            if (!Guid.TryParse(code, out Guid value)) throw new WrongCodeException(code);
            Value = value;
        }

        public Code(Guid value)
        {
            if (value == Guid.Empty) throw new WrongCodeException();
            Value = value;
        }

        public static implicit operator Code(string value) => new(value);
        public static implicit operator Code(Guid value) => new(value);

        public static implicit operator Guid(Code value) => value.Value;
        public static implicit operator string(Code value) => value.Value.ToString();
    }
}
