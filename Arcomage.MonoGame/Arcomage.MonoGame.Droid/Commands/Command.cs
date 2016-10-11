using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class Command : ICommand
    {
        public virtual bool CanExecute(object parameter) => true;

        public virtual void Execute(object parameter) { }

        public event EventHandler CanExecuteChanged;
    }
}