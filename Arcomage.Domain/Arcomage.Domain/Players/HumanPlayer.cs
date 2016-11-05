using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Players
{
    public class HumanPlayer : Player
    {
        public PlayResult PlayResult { get; set; }

        public override async Task<PlayResult> Play(Game game)
        {
            while (Equals(PlayResult, PlayResult.None))
                await Task.Delay(100);

            var result = PlayResult;
            PlayResult = PlayResult.None;

            return result;
        }
    }
}
