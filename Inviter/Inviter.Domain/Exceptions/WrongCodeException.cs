using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class WrongCodeException : Exception
    {
        public WrongCodeException() : base("Code is empty")
        { }

        public WrongCodeException(string? message) : base($"Cannot parse code with value: {message}")
        {
        }

        public WrongCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
