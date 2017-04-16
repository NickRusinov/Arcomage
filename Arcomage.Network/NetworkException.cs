using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class NetworkException : Exception
    {
        public NetworkException()
        {
        }

        public NetworkException(string message) 
            : base(message)
        {
        }

        public NetworkException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected NetworkException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
