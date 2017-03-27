using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Actions
{
    public class TerminatePlayCardAction : IPlayCardAction
    {
        public Task Play(Game game, PlayResult playResult)
        {
            return FrameworkExtensions.CompletedTask();
        }
    }
}
