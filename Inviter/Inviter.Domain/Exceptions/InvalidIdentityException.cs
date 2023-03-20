using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class InvalidIdentityException : Exception
    {
        public InvalidIdentityException() : base("Identity is empty")
        {
        }

        public InvalidIdentityException(string? message) : base($"Cannot parse identity with value: {message}")
        {
        }

        public InvalidIdentityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidIdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
