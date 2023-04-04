using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class InvitationNotFoundException : Exception
    {
        public InvitationNotFoundException()
        {
        }

        public InvitationNotFoundException(string? message) : base($"Cannot find invitation with code: {message}")
        {
        }

        public InvitationNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvitationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
