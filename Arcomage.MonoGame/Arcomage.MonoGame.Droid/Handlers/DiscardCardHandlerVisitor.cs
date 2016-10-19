using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Views;
using static System.Math;

namespace Arcomage.MonoGame.Droid.Handlers
{
    public class DiscardCardHandlerVisitor : DragBaseHandlerVisitor
    {
        private readonly CardView cardView;

        private readonly float delta;

        public DiscardCardHandlerVisitor(CardView cardView, float delta)
            : base(cardView)
        {
            this.cardView = cardView;
            this.delta = delta;
        }

        public override bool Visit(DragEndHandlerData handlerData)
        {
            var handled = base.Visit(handlerData);
            if (handled)
                if (Abs(cardView.Position.Y - InitPosition.Y) >= Abs(delta) && Sign(cardView.Position.Y - InitPosition.Y) == Sign(delta))
                    if (cardView.ViewModel.DiscardCommand.CanExecute(cardView.ViewModel))
                        cardView.ViewModel.DiscardCommand.Execute(cardView.ViewModel);

            return handled;
        }
    }
}