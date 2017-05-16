using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Компаратор, сравнивающий успешность одного варианта контекста игры с другим
    /// </summary>
    public class GameComparer : IComparer<Game>
    {
        /// <summary>
        /// Номер текущего игрока
        /// </summary>
        private readonly PlayerKind currentPlayerKind;

        /// <summary>
        /// Номер соперничающего игрока
        /// </summary>
        private readonly PlayerKind adversaryPlayerKind;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="GameComparer"/>
        /// </summary>
        /// <param name="currentPlayerKind">Номер текущего игрока</param>
        /// <param name="adversaryPlayerKind">Номер соперничающего игрока</param>
        public GameComparer(PlayerKind currentPlayerKind, PlayerKind adversaryPlayerKind)
        {
            this.currentPlayerKind = currentPlayerKind;
            this.adversaryPlayerKind = adversaryPlayerKind;
        }
        
        /// <summary>
        /// Сравнивает один контекст игры с другим путем сравнения их весов
        /// </summary>
        /// <param name="x">Первый контект игры</param>
        /// <param name="y">Второй контекст игры</param>
        /// <returns>Результат сравнения</returns>
        public int Compare(Game x, Game y)
        {
            bool currentIsWin = x.Rule.IsWin(x);
            bool adversaryIsWin = y.Rule.IsWin(y);

            if (currentIsWin || adversaryIsWin)
                return currentIsWin.CompareTo(adversaryIsWin);

            var currentWeight = GetWeight(x);
            var adversaryWeight = GetWeight(y);

            return currentWeight.CompareTo(adversaryWeight);
        }

        /// <summary>
        /// Получает значение веса контекста игры для сравнения
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Вес контекста игры</returns>
        private float GetWeight(Game game)
        {
            var currentPlayer = game.Players[currentPlayerKind];
            var adversaryPlayer = game.Players[adversaryPlayerKind];

            var currentWeight = GetWeight(currentPlayer);
            var adversaryWeight = GetWeight(adversaryPlayer);

            return currentWeight - adversaryWeight;
        }

        /// <summary>
        /// Получает значение веса характеристик игрока для сравнения
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <returns>Вес характеристик игрока</returns>
        private float GetWeight(Player player)
        {
            return player.Buildings.Tower * 1f +
                player.Buildings.Wall * .25f +
                player.Resources.Quarry * 4f +
                player.Resources.Magic * 4f +
                player.Resources.Dungeons * 4f +
                player.Resources.Bricks * .05f +
                player.Resources.Gems * .05f +
                player.Resources.Recruits * .05f;
        }
    }
}
