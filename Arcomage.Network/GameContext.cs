using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class GameContext
    {
        public static GameContext New(UserContext firstUser, UserContext secondUser)
        {
            return new GameContext
            {
                Id = Guid.NewGuid(),
                JobId = "",
                Version = 0,
                State = GameState.Created,
                CreatedDate = DateTime.UtcNow,
                StartedDate = null,
                FinishedDate = null,
                FirstUser = firstUser,
                SecondUser = secondUser,
            };
        }

        public Guid Id { get; set; }

        public string JobId { get; set; }

        public int Version { get; set; }

        public GameState State { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? StartedDate { get; set; }

        public DateTime? FinishedDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        public UserContext FirstUser { get; set; }

        public UserContext SecondUser { get; set; }
    }
}
