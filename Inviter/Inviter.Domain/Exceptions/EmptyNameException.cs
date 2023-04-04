using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class EmptyNameException : Exception
    {
        public EmptyNameException() : base("Name is empty")
        {

        }

        public EmptyNameException(string? message) : base(message)
        {
        }

        public EmptyNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
