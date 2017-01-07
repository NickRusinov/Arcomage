using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Players
{
    [Serializable]
    public class HumanPlayer : Player
    {
        [NonSerialized]
        private TaskCompletionSource<PlayResult> playResultSource;

        public HumanPlayer(Buildings buildings, Resources resources, Hand hand)
            : base(buildings, resources, hand)
        {
            
        }

        public void SetPlayResult(PlayResult playResult)
        {
            playResultSource?.TrySetResult(playResult);
        }

        public override Task<PlayResult> Play(Game game)
        {
            playResultSource = new TaskCompletionSource<PlayResult>();

            return playResultSource.Task;
        }
    }
}
