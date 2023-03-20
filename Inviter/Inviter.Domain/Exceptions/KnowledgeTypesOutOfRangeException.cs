using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Exceptions
{
    [Serializable]
    public class KnowledgeTypesOutOfRangeException : Exception
    {
        public KnowledgeTypesOutOfRangeException()
        {
        }

        public KnowledgeTypesOutOfRangeException(string? message) : base($"KnowledgeTypes is out of range for value: {message}")
        {
        }

        public KnowledgeTypesOutOfRangeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected KnowledgeTypesOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
