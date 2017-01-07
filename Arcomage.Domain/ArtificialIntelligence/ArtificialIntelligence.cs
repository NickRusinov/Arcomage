using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Services;

namespace Arcomage.Domain.ArtificialIntelligence
{
    [Serializable]
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private readonly GameLoop gameLoop;

        private readonly IPlayCardCriteria playCardCriteria;

        private readonly IDiscardCardCriteria discardCardCriteria;

        public ArtificialIntelligence(GameLoop gameLoop, IPlayCardCriteria playCardCriteria, IDiscardCardCriteria discardCardCriteria)
        {
            this.gameLoop = gameLoop;
            this.playCardCriteria = playCardCriteria;
            this.discardCardCriteria = discardCardCriteria;
        }

        public Task<PlayResult> Execute(Game game, Player player)
        {
            var isFirstPlayer = ReferenceEquals(game.FirstPlayer, player);

            var comparer = new GameComparer(
                g => isFirstPlayer ? g.FirstPlayer : g.SecondPlayer,
                g => isFirstPlayer ? g.SecondPlayer : g.FirstPlayer);
            
            return Task.Factory.StartNew(() => GetPossiblePlay(game)
                .OrderByDescending(p => p.Key, comparer)
                .Select(p => new PlayResult?(p.Value))
                .FirstOrDefault() ?? new PlayResult(0, false));
        }
        
        private IEnumerable<KeyValuePair<Game, PlayResult>> GetPossiblePlay(Game game)
        {
            for (var i = 0; i < game.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = FrameworkExtensions.Copy(game);
                var playResult = new PlayResult(i, true);

                if (playCardCriteria.CanPlayCard(cloneGame, cloneGame.CurrentPlayer, i))
                {
                    gameLoop.Update(cloneGame, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }

            for (var i = 0; i < game.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = FrameworkExtensions.Copy(game);
                var playResult = new PlayResult(i, false);

                if (discardCardCriteria.CanDiscardCard(cloneGame, cloneGame.CurrentPlayer, i))
                {
                    gameLoop.Update(cloneGame, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }
        }
    }
}
