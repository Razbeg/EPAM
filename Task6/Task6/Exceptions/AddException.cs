using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task6.Exceptions
{
    [Serializable]
    public class AddException : Exception
    {
        public AddException(string message) : base(message)
        {
        }

        public AddException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
