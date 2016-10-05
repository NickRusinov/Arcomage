using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Services
{
    public class PlayCardService : IPlayCardService
    {
        private readonly IActivateCardService activateCardService;

        private readonly IReplaceCardService replaceCardService;

        private readonly IReplacePlayerService replacePlayerService;

        public PlayCardService(IActivateCardService activateCardService, IReplaceCardService replaceCardService, IReplacePlayerService replacePlayerService)
        {
            this.activateCardService = activateCardService;
            this.replaceCardService = replaceCardService;
            this.replacePlayerService = replacePlayerService;
        }

        public void PlayCard(int cardIndex)
        {
            activateCardService.ActivateCard(cardIndex);
            replaceCardService.ReplaceCard(cardIndex);
            replacePlayerService.ReplacePlayer();
        }
    }
}
