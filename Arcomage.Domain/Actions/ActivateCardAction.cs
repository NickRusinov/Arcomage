﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет действия, связанные с активацией или сбросом карты
    /// </summary>
    public class ActivateCardAction : IPlayAction
    {
        private readonly IPlayAction nextAction;
        
        public ActivateCardAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            var card = player.Hand[playResult.Card];
            var resource = player.Resources[card.Kind];
            
            game.DiscardOnly--;

            if (playResult.IsPlay)
            {
                resource.Value -= card.Price;
                card.Activate(game);
            }

            return nextAction.Play(game, player, playResult);
        }

        /// <inheritdoc/>
        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            var card = player.Hand[playResult.Card];
            var resource = player.Resources[card.Kind];

            var canPlay = true;
            canPlay &= playResult.IsDiscard || game.DiscardOnly <= 0;
            canPlay &= playResult.IsDiscard || card.Price <= resource.Value;
            canPlay &= nextAction.CanPlay(game, player, playResult);

            return canPlay;
        }
    }
}
