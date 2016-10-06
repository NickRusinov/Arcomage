using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Exceptions
{
    public class GameFinishedException : ArcomageException
    {
        public GameFinishedException()
        {
            
        }

        public GameFinishedException(string message)
            : base(message)
        {
            
        }

        public GameFinishedException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
