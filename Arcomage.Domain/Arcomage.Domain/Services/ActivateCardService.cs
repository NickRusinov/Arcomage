using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;

namespace Arcomage.Domain.Services
{
    public class ActivateCardService : IActivateCardService
    {
        private readonly Game game;

        private readonly Player player;

        public ActivateCardService(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void ActivateCard(int cardIndex)
        {
            var card = player.CardSet.Cards[cardIndex];

            if (!card.IsEnoughResources(player.Resources))
                throw new NotEnoughResourcesException();

            card.Activate(game);
            card.PaymentResources(player.Resources);
        }
    }
}
