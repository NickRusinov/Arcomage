using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Services
{
    public class DiscardCardService : IDiscardCardService
    {
        private readonly IReplaceCardService replaceCardService;

        private readonly IReplacePlayerService replacePlayerService;

        public DiscardCardService(IReplaceCardService replaceCardService, IReplacePlayerService replacePlayerService)
        {
            this.replaceCardService = replaceCardService;
            this.replacePlayerService = replacePlayerService;
        }

        public void DiscardCard(int cardIndex)
        {
            replaceCardService.ReplaceCard(cardIndex);
            replacePlayerService.ReplacePlayer();
        }
    }
}
