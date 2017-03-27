using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет действия, связанные с активацией или сбросом карты
    /// </summary>
    public class ActivateCardAction : IPlayCardAction
    {
        private readonly IPlayCardAction nextAction;
        
        public ActivateCardAction(IPlayCardAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task Play(Game game, PlayResult playResult)
        {
            var card = game.Players.CurrentPlayer.Hand[playResult.Card];
            var resource = game.Players.CurrentPlayer.Resources[card.Kind];
            
            game.DiscardOnly--;

            if (playResult.IsPlay)
            {
                resource.Value -= card.Price;
                card.Activate(game);
            }

            return nextAction.Play(game, playResult);
        }
    }
}
