using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class CommandDispatcher
    {
        private readonly Dictionary<Type, Action<object>> executorRegistry = new Dictionary<Type, Action<object>>();

        private readonly Dictionary<Type, Func<object, bool>> canExecutorRegistry = new Dictionary<Type, Func<object, bool>>();
        
        public void RegisterExecutor<TCommand>(ICommandExecutor<TCommand> executor)
        {
            executorRegistry[typeof(TCommand)] = o => executor.Execute((TCommand)o);
        }

        public void RegisterCanExecutor<T>(ICommandCanExecutor<T> canExecutor)
        {
            canExecutorRegistry[typeof(T)] = o => canExecutor.CanExecute((T)o);
        }

        public bool CanExecute(object command)
        {
            Func<object, bool> canExecutor;
            return !canExecutorRegistry.TryGetValue(command.GetType(), out canExecutor) || canExecutor.Invoke(command);
        }

        public void Execute(object command)
        {
            Action<object> executor;
            if (CanExecute(command) && executorRegistry.TryGetValue(command.GetType(), out executor))
                executor.Invoke(command);
        }
    }
}
