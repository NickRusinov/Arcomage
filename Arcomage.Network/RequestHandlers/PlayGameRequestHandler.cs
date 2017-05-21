using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.RequestHandlers
{
    public class PlayGameRequestHandler : IRequestHandler<PlayCardGameRequest>, IRequestHandler<DiscardCardGameRequest>
    {
        public void Handle(PlayCardGameRequest message)
        {
            var humanPlayer = GetHumanPlayer(message.GameContext, message.User);

            humanPlayer.SetPlayResult(new PlayResult(message.Index, true));
        }

        public void Handle(DiscardCardGameRequest message)
        {
            var humanPlayer = GetHumanPlayer(message.GameContext, message.User);

            humanPlayer.SetPlayResult(new PlayResult(message.Index, false));
        }

        private HumanPlayer GetHumanPlayer(GameContext gameContext, User user)
        {
            if (gameContext.FirstUser.Id == user.Id && gameContext.Game.Players.Kind != PlayerKind.First)
                throw new NetworkException(Resources.NotPlayedHumanPlayer);

            if (gameContext.SecondUser.Id == user.Id && gameContext.Game.Players.Kind != PlayerKind.Second)
                throw new NetworkException(Resources.NotPlayedHumanPlayer);

            if (!(gameContext.Game.Players.CurrentPlayer is HumanPlayer humanPlayer))
                throw new NetworkException(Resources.NotPlayedHumanPlayer);

            return humanPlayer;
        }
    }
}
