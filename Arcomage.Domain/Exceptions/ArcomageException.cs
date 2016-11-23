using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Exceptions
{
    public abstract class ArcomageException : Exception
    {
        protected ArcomageException()
        {
            
        }

        protected ArcomageException(string message)
            : base(message)
        {
            
        }

        protected ArcomageException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
