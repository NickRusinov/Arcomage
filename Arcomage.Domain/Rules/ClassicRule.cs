using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using static Arcomage.Domain.Players.PlayerSet;

namespace Arcomage.Domain.Rules
{
    /// <summary>
    /// Классические правила игры
    /// </summary>
    [Serializable]
    public class ClassicRule : Rule
    {
        /// <summary>
        /// Описание классических правил игры
        /// </summary>
        private readonly ClassicRuleInfo ruleInfo;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ClassicRule"/>
        /// </summary>
        /// <param name="ruleInfo">Описание классических правил игры</param>
        public ClassicRule(ClassicRuleInfo ruleInfo)
        {
            Contract.Requires(ruleInfo != null);

            this.ruleInfo = ruleInfo;
        }

        /// <inheritdoc/>
        public override BuildingSet CreateBuildings()
        {
            return new BuildingSet(ruleInfo.Wall, ruleInfo.Tower);
        }

        /// <inheritdoc/>
        public override ResourceSet CreateResources()
        {
            return new ResourceSet(ruleInfo.Quarry, ruleInfo.Bricks, ruleInfo.Magic, ruleInfo.Gems, ruleInfo.Dungeons, ruleInfo.Recruits);
        }

        /// <inheritdoc/>
        public override GameResult IsWin(Game game)
        {
            var currentGameResult = IsWinPlayer(game, game.Players.Kind, NextPlayerKind(game.Players.Kind));
            if (currentGameResult)
                return currentGameResult;

            var adversaryGameResult = IsWinPlayer(game, NextPlayerKind(game.Players.Kind), game.Players.Kind);
            if (adversaryGameResult)
                return adversaryGameResult;

            return GameResult.None;
        }

        /// <summary>
        /// Получение результата игры для определенного игрока
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="winPlayerKind">Игрок, для победы которого выполняет проверка</param>
        /// <param name="losePlayerKind">Игрока, для поражения которого выполняется проверка</param>
        /// <returns>Результат игры для конкретного игрока</returns>
        private GameResult IsWinPlayer(Game game, PlayerKind winPlayerKind, PlayerKind losePlayerKind)
        {
            Contract.Requires(game != null);
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), winPlayerKind));
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), losePlayerKind));

            var winPlayer = game.Players[winPlayerKind];
            var losePlayer = game.Players[losePlayerKind];

            if (winPlayer.Buildings.Tower >= ruleInfo.MaxTower)
                return new GameResult(winPlayerKind, true, false, false);

            if (losePlayer.Buildings.Tower <= 0)
                return new GameResult(winPlayerKind, false, true, false);

            if (winPlayer.Resources.Bricks >= ruleInfo.MaxResources &&
                winPlayer.Resources.Gems >= ruleInfo.MaxResources &&
                winPlayer.Resources.Recruits >= ruleInfo.MaxResources)
                return new GameResult(winPlayerKind, false, false, true);

            return GameResult.None;
        }
    }
}
