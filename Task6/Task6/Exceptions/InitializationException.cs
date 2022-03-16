using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task6.Exceptions
{
    [Serializable]
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base(message)
        {
        }

        public InitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
