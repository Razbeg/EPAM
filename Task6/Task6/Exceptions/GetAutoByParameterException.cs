using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task6.Exceptions
{
    [Serializable]
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message) : base(message)
        {
        }

        public GetAutoByParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GetAutoByParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
