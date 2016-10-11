using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class ButtonClickHandlerVisitor : HandlerVisitor
    {
        private readonly MenuButtonView buttonView;

        public ButtonClickHandlerVisitor(MenuButtonView buttonView)
        {
            this.buttonView = buttonView;
        }

        public override bool Visit(ClickHandlerData handlerData)
        {
            if (!buttonView.Rectangle.Contains(handlerData.Position))
                return false;

            if (buttonView.ViewModel.Command.CanExecute(buttonView.ViewModel))
                buttonView.ViewModel.Command.Execute(buttonView.ViewModel);
            return true;
        }
    }
}