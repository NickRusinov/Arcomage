using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Exceptions
{
    public class NotEnoughResourcesException : ArcomageException
    {
        public NotEnoughResourcesException()
        {
            
        }

        public NotEnoughResourcesException(string message)
            : base(message)
        {
            
        }

        public NotEnoughResourcesException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
