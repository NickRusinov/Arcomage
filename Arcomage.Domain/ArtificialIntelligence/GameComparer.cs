using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.ArtificialIntelligence
{
    public class GameComparer : IComparer<Game>
    {
        private readonly Func<Game, Player> currentSelector;

        private readonly Func<Game, Player> adversarySelector;

        public GameComparer(Func<Game, Player> currentSelector, Func<Game, Player> adversarySelector)
        {
            this.currentSelector = currentSelector;
            this.adversarySelector = adversarySelector;
        }

        public int Compare(Game x, Game y)
        {
            if (x.Result)
                return +1;

            if (y.Result)
                return -1;

            var currentWeight = GetWeight(x);
            var adversaryWeight = GetWeight(y);

            return currentWeight.CompareTo(adversaryWeight);
        }

        private float GetWeight(Game game)
        {
            var currentPlayer = currentSelector.Invoke(game);
            var adversaryPlayer = adversarySelector.Invoke(game);

            var currentWeight = GetWeight(currentPlayer);
            var adversaryWeight = GetWeight(adversaryPlayer);

            return currentWeight - adversaryWeight;
        }

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
