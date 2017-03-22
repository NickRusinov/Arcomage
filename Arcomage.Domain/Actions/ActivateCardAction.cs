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
    public class ActivateCardAction : IAfterPlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game, PlayResult playResult)
        {
            var card = game.Players.CurrentPlayer.Hand.Cards[playResult.Card];
            var resource = game.Players.CurrentPlayer.Resources[card.Kind];
            
            game.DiscardOnly--;

            if (playResult.IsPlay)
            {
                resource.Value -= card.Price;
                card.Activate(game);
            }
        }
    }
}
