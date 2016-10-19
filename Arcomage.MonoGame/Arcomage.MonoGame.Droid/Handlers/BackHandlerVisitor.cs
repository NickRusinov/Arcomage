using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Arcomage.MonoGame.Droid.ViewModels;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class BackHandlerVisitor : HandlerVisitor
    {
        private readonly ViewModel viewModel;

        private readonly ICommand command;

        public BackHandlerVisitor(ViewModel viewModel, ICommand command)
        {
            this.viewModel = viewModel;
            this.command = command;
        }

        public override bool Visit(BackHandlerData handlerData)
        {
            if (command.CanExecute(viewModel))
                command.Execute(viewModel);

            return true;
        }
    }
}