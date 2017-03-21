using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public interface ICommandExecutor<TCommand>
    {
        void Execute(TCommand command);
    }
}
