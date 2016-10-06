using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    public class ReplaceCardGameAction : IGameAction
    {
        private readonly Game game;

        private readonly Player player;

        public ReplaceCardGameAction(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void Execute(int cardIndex)
        {
            var oldCard = player.CardSet.Cards[cardIndex];

            game.CardDeck.PushCard(game, oldCard);
            var newCard = game.CardDeck.PopCard(game);

            player.CardSet.Cards[cardIndex] = newCard;
        }
    }
}
