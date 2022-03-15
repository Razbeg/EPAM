using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task6.Exceptions
{
    [Serializable]
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException()
        {
        }

        public RemoveAutoException(string message) : base(message)
        {
        }

        public RemoveAutoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RemoveAutoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
