using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.Unity.Shared.Scripts
{
    public class NetworkSettings
    {
        public Guid GameId = Guid.NewGuid();

        public GameModel GameModel { get; set; }
    }
}
