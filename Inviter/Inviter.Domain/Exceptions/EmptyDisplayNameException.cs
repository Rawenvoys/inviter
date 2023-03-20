using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class EmptyDisplayNameException : Exception
    {
        public EmptyDisplayNameException() : base("Display name is empty")
        {

        }

        public EmptyDisplayNameException(string? message) : base(message)
        {
        }

        public EmptyDisplayNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyDisplayNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
