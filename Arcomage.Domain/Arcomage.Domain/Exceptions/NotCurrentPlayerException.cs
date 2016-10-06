using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Exceptions
{
    public class NotCurrentPlayerException : ArcomageException
    {
        public NotCurrentPlayerException()
        {
            
        }

        public NotCurrentPlayerException(string message)
            : base(message)
        {
            
        }

        public NotCurrentPlayerException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
