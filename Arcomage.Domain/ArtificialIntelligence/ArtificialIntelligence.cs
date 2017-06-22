using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Players;
using static Arcomage.Domain.Extensions;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Стандартная реализация алгоритма ИИ для компьютерного игрока
    /// </summary>
    [Serializable]
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private readonly IPlayAction playAction;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ArtificialIntelligence"/>
        /// </summary>
        public ArtificialIntelligence(IPlayAction playAction)
        {
            Contract.Requires(playAction != null);

            this.playAction = playAction;
        }

        /// <inheritdoc/>
        public async Task<PlayResult> Execute(Game game, Player player)
        {
            var isFirstPlayer = ReferenceEquals(game.Players.FirstPlayer, player);

            var comparer = new GameComparer(
                isFirstPlayer ? PlayerKind.First : PlayerKind.Second,
                isFirstPlayer ? PlayerKind.Second : PlayerKind.First);

            await Delay(TimeSpan.FromSeconds(1));
            
            return GetPossiblePlay(game)
                .OrderByDescending(p => p.Key, comparer)
                .Select(p => p.Value)
                .DefaultIfEmpty(new PlayResult(0, false, true, false))
                .First();
        }
        
        /// <summary>
        /// Получает возможные варианты ходов
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Коллекция возможных вариантов ходов</returns>
        private IEnumerable<KeyValuePair<Game, PlayResult>> GetPossiblePlay(Game game)
        {
            for (var i = 0; i < game.Players.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = Copy(game);
                var playResult = new PlayResult(i, true, false, false);

                if (playAction.CanPlay(cloneGame, cloneGame.Players.CurrentPlayer, playResult))
                {
                    playAction.Play(cloneGame, cloneGame.Players.CurrentPlayer, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }

            for (var i = 0; i < game.Players.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = Copy(game);
                var playResult = new PlayResult(i, false, true, false);

                if (playAction.CanPlay(cloneGame, cloneGame.Players.CurrentPlayer, playResult))
                {
                    playAction.Play(cloneGame, cloneGame.Players.CurrentPlayer, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }
        }
    }
}
