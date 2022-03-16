using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task6.Exceptions
{
    [Serializable]
    internal class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message)
        {
        }

        public UpdateAutoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateAutoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
